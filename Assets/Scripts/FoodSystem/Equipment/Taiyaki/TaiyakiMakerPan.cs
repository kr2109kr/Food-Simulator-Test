using FoodSystem;
using System;
using System.Collections;
using UnityEditor.Animations;
using UnityEngine;

public class TaiyakiMakerPan : MonoBehaviour, IInteractor
{
    [SerializeField] private TaiyakiMakerTray[] _trays;
    [SerializeField] private TaiyakiMaker _taiyakiMaker;
    public bool IsOpen { get; set; } = true;

    [SerializeField] private GameObject taiyaki;

    [field: SerializeField] public Side SideOfPan { get; private set; }

    [SerializeField] private Equipment _requiredEquipment;


    [SerializeField] private Quaternion _rotation;


    [SerializeField] private Animator _animator;


    [SerializeField] private string _closeAnimName = "Close";
    [SerializeField] private string _openAnimName = "Open";

    [SerializeField] private GameObject _combinedTaiyakiPrefabs;

    public enum Side
    {
        Left,
        Right
    }

    private void Awake()
    {
        

        AnimatorController animatorController = _animator.runtimeAnimatorController as AnimatorController;

        AnimatorStateMachine animatorStateMachine = animatorController.layers[0].stateMachine;

        _animator.Play(animatorStateMachine.defaultState.name, 0, 1f); //Set Default Animation State


        //animatorStateMachine.defaultState.speed = 1f;
    }
    public void Interact(Player player)
    {
        if (!IsOpen && player.GetEquipment() == null)
        {
            Open();

        }

        else if (IsOpen && player.GetEquipment() is null)
        {
            Close();
            PlayCloseAnimation();

            StartCoroutine(PlayAnimationAndWait(_closeAnimName, 0, () =>
            {
                _taiyakiMaker.StartCombine(this);
                EnableCollider();
                //Debug.Log("Opennnn");
            }));
        }
    }

    public void Open()
    {
        IsOpen = true;

        PlayOpenAnimation();

        GetAnotherPan().EnableCollider();
    }

    public void Close()
    {
        IsOpen = false;

        PlayCloseAnimation();

        GetAnotherPan().DisableCollider();
    }

    private void PlayOpenAnimation()
    {
        _animator.SetBool("IsOpen", true);

        DisableCollider();
        StartCoroutine(PlayAnimationAndWait(_openAnimName, 0, () => { EnableCollider(); Debug.Log("Opennnn"); }));
        
    }

    private void PlayCloseAnimation()
    {
        _animator.SetBool("IsOpen", false);

        DisableCollider();
        
    }

    

    private void EnableCollider()
    {
        GetComponent<BoxCollider>().enabled = true;
    }

    private void DisableCollider()
    {
        GetComponent<BoxCollider>().enabled = false;
    }

    public int GetTraysLength()
    {
        return _trays.Length;
    }


    public void CreateCombinedAtTray(int indexOfTray)
    {
        //GetAnotherPan()._trays[indexOfTray].CreateCombinedTaiyaki();
        //GetAnotherPan()._trays[indexOfTray].SetCombinedTaiyaki(GetTaiyaki(indexOfTray));


        //TaiyakiData.Filling targerFilling = 0; //ประกาศใน method จะไม่มีค่า default






        var t = Instantiate(_combinedTaiyakiPrefabs, GetAnotherPan()._trays[indexOfTray].transform);



        var anotherTaiyakiFilling = GetAnotherPan()._trays[indexOfTray].TaiyakiGameObject.GetComponent<SideTaiyaki>()._dataForCheck.filling;
        var thisTaiyakiFilling = _trays[indexOfTray].TaiyakiGameObject.GetComponent<SideTaiyaki>()._dataForCheck.filling;


        if (anotherTaiyakiFilling != TaiyakiData.Filling.None)
        {
            switch (anotherTaiyakiFilling)
            {
                case TaiyakiData.Filling.RedBeans:
                    t.GetComponent<Taiyaki>().SetFillingData(TaiyakiData.Filling.RedBeans);
                    break;
                case TaiyakiData.Filling.Custard:
                    t.GetComponent<Taiyaki>().SetFillingData(TaiyakiData.Filling.Custard);
                    break;
                case TaiyakiData.Filling.Chocolate:
                    t.GetComponent<Taiyaki>().SetFillingData(TaiyakiData.Filling.Chocolate);
                    break;

            }
        }

        if (thisTaiyakiFilling != TaiyakiData.Filling.None)
        {
            switch (thisTaiyakiFilling)
            {
                case TaiyakiData.Filling.RedBeans:
                    t.GetComponent<Taiyaki>().SetFillingData(TaiyakiData.Filling.RedBeans);
                    break;
                case TaiyakiData.Filling.Custard:
                    t.GetComponent<Taiyaki>().SetFillingData(TaiyakiData.Filling.Custard);
                    break;
                case TaiyakiData.Filling.Chocolate:
                    t.GetComponent<Taiyaki>().SetFillingData(TaiyakiData.Filling.Chocolate);
                    break;
            }
        }

        Debug.Log(t.GetComponent<Taiyaki>()._dataForCheck.filling);

        Destroy(GetAnotherPan()._trays[indexOfTray].TaiyakiGameObject);
        Destroy(_trays[indexOfTray].TaiyakiGameObject);
        //t.GetComponent<Taiyaki>()._dataForCheck.filling = targerFilling;
        GetAnotherPan()._trays[indexOfTray].SetCombinedTaiyaki(t.GetComponent<Taiyaki>());
    }


    //
    public void Switch(int index)
    {
        if (_trays[index].combinedTaiyaki != null)
        {
            _trays[index].combinedTaiyaki.transform.SetParent(GetAnotherPan()._trays[index].transform);

            GetAnotherPan()._trays[index].RecieveCombinedTaiyaki(_trays[index].combinedTaiyaki);
            _trays[index].RemoveToOtherTray();
        }
        else
        {
            GetAnotherPan()._trays[index].combinedTaiyaki.transform.SetParent(_trays[index].transform);
            GetAnotherPan()._trays[index].RemoveToOtherTray();

            _trays[index].RecieveCombinedTaiyaki(GetAnotherPan()._trays[index].combinedTaiyaki);
            GetAnotherPan()._trays[index].RemoveToOtherTray();
        }
    }
    //

    public TaiyakiMakerPan GetAnotherPan()
    {
        if (SideOfPan == Side.Left)
        {
            return _taiyakiMaker._rightPan;
        }

        else if (SideOfPan == Side.Right)
        {
            return _taiyakiMaker._leftPan;
        }

        else return null;
    }

    private IEnumerator PlayAnimationAndWait(string name, int layer, Action action)
    {
        yield return WaitForAnimation(name, layer);
        action();
    }

    private IEnumerator WaitForAnimation(string name, int layer)
    {
        while (!_animator.IsInTransition(layer))
        {
            yield return null;
        }

        while (_animator.IsInTransition(layer))
        {
            yield return null;
        }

        if (_animator.GetCurrentAnimatorStateInfo(layer).IsName(name))
        {
            while (_animator.GetCurrentAnimatorStateInfo(layer).normalizedTime < 1f)
            {
                yield return null;
            }
        }

        Debug.Log("Animation has Finished");
    }

    public TaiyakiMakerTray GetTrays(int indexOfTray)
    {
        return _trays[indexOfTray];
    }

    public TaiyakiOld GetTaiyaki(int index)
    {
        return _trays[index].TaiyakiGameObject.GetComponent<TaiyakiOld>();
    }

    private void GetCombinedTaiyaki()
    {
        return;
    }

    

    /// <summary>
    /// //
    /// </summary>
    /// <param name="index"></param>

    public bool IsTrayNotEmpty(int index)
    {
        return (_trays[index].IsNotEmpty());
    }

    public bool DoesTrayHasCombined(int index)
    {
        return (_trays[index].combinedTaiyaki);
    }

    
}
