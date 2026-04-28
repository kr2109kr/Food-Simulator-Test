using FoodSystem;
using System;
using System.Collections;
using UnityEngine;

public class TakoyakiMakerTray : MonoBehaviour, IInteractor
{
    private GameObject _halfTakoyakiPrefabs;
    private GameObject _fullTakoyakiPrefabs;
    private GameObject _currentObject;


    private GameObject _curremtHaldTakoyaki;

    [Header("FillFlour")]
    [SerializeField] private Vector3 _startPosition;
    [SerializeField] private Vector3 _target = Vector3.zero;
    [SerializeField] private float _fillSpeed;


    [Header("Takoyaki Filling")]
    [SerializeField] private Vector3 _startFillingPosition;
    [SerializeField] private Vector3 _targetFilling = Vector3.zero;
    [SerializeField] private float _fillFiliingSpeed;


    private bool _isTrayEmpty = true;
    private State _state;



    

    private enum State
    {
        Empty,
        HasFlour,
        HasFilling,
        HasQuarterFlip,
        HasHalfFlip,
        HasThreeQuartersFlip,
        HasFullFlip,
        WaitingForFullFlip,
        WaitingForAllSideCooked
    }

    private void Awake()
    {
        _halfTakoyakiPrefabs = GetComponentInParent<TakoyakiMaker>().HalfTakoyakilPrefab;
        _fullTakoyakiPrefabs = GetComponentInParent<TakoyakiMaker>().FullTakoyakiPrefab;
    }

    public void Interact(Player player)
    {
        if (_state == State.Empty)
        {
            if (player.GetEquipment()?.Check(typeof(Kettle)) ?? false)
            {
                var _kettle = player.GetEquipment().GetComponent<Kettle>();
                _kettle.IsPouring();

                FillFlour();
                Debug.Log("wwww");

                _state++;
            }
        }

        else if (_state == State.HasFlour)
        {
            if (player.GetEquipment()?.Check(typeof(TakoyakiFillingSpoon)) ?? false)
            {
                var FillingSpoon = player.GetEquipment().GetComponent<TakoyakiFillingSpoon>();

                if (FillingSpoon.Filling == TakoyakiData.Filling.Tako)
                {
                    _currentObject.GetComponent<HalfTakoyaki>().ShowTako();
                }
                else if (FillingSpoon.Filling == TakoyakiData.Filling.Shrimp)
                {
                    _currentObject.GetComponent<HalfTakoyaki>().ShowShrimp();
                }
                else if (FillingSpoon.Filling == TakoyakiData.Filling.Bacon)
                {
                    _currentObject.GetComponent<HalfTakoyaki>().ShowBacon();
                }

                //AddFilling(FillingSpoon.Filling, FillingSpoon.FillingPrefab);


                _state++;
            }
        }

        else if (_state == State.HasFilling)
        {
            if (player.GetEquipment()?.Check(typeof(FlipStick)) ?? false)
            {
                FlipTakoyaki(45);
                _state++;
            }
        }

        else if (_state == State.HasQuarterFlip)
        {
            if (player.GetEquipment()?.Check(typeof(FlipStick)) ?? false)
            {
                FlipTakoyaki(90);
                _state++;
            }
        }

        else if (_state == State.HasHalfFlip)
        {
            if (player.GetEquipment()?.Check(typeof(FlipStick)) ?? false)
            {
                FlipTakoyaki(135);
                _state++;
            }
        }

        else if (_state == State.HasThreeQuartersFlip)
        {
            if (player.GetEquipment()?.Check(typeof(FlipStick)) ?? false)
            {
                FlipTakoyaki(180);
                _state++;

                Destroy(_currentObject);

                _currentObject = Instantiate(_fullTakoyakiPrefabs, transform);
                

            }
        }

        else if (_state == State.HasFullFlip)
        {
            if (player.GetEquipment()?.Check(typeof(Tongs)) ?? false)
            {
                var tongs = player.GetEquipment().GetComponent<Tongs>();

                tongs.PickUp(_currentObject);
                _state++;
            }
        }

        
    }

    private void AddMoreFlour()
    {
        throw new NotImplementedException();
    }

    public void FillFlour()
    {
        var temp = Instantiate(_halfTakoyakiPrefabs, transform);
        temp.transform.localPosition = _startPosition;



        //TaiyakiGameObject.GetComponent<SideTaiyaki>().StartCooking();

        StartCoroutine(FillFlour(temp.transform));


        IEnumerator FillFlour(Transform objectTransform)
        {
            float step = _fillSpeed * Time.fixedDeltaTime;
            Vector3 target = new Vector3(objectTransform.localPosition.x, _target.y, objectTransform.localPosition.z);


            while (objectTransform.localPosition.y != target.y)
            {
                objectTransform.localPosition = Vector3.MoveTowards(objectTransform.transform.localPosition, target, step);
                yield return null;
            }
            //TakoyakiGanme
            //rawTaiyaki.GetComponent<SideTaiyaki>().StartCooking();
        }

        if (_currentObject == null)
        {
            _currentObject = temp;
        }
    }

    public void AddFilling(TakoyakiData.Filling filling, GameObject prefab)
    {
        _currentObject.GetComponent<HalfTakoyaki>().SetFilling(filling);
        Debug.Log(_currentObject.GetComponent<HalfTakoyaki>().GetFilling());



        var temp = Instantiate(prefab, _currentObject.transform);
        temp.transform.localPosition = _startPosition;



        //TaiyakiGameObject.GetComponent<SideTaiyaki>().StartCooking();

        StartCoroutine(FillFlour(temp.transform));


        IEnumerator FillFlour(Transform objectTransform)
        {
            float step = _fillSpeed * Time.fixedDeltaTime;
            Vector3 target = new Vector3(objectTransform.localPosition.x, _target.y, objectTransform.localPosition.z);


            while (objectTransform.localPosition.y != target.y)
            {
                objectTransform.localPosition = Vector3.MoveTowards(objectTransform.transform.localPosition, target, step);
                yield return null;
            }
            //TakoyakiGanme
            //rawTaiyaki.GetComponent<SideTaiyaki>().StartCooking();
        }
    }

    public void FlipTakoyaki(float zEulerAngle)
    {
        _currentObject.transform.localRotation = Quaternion.Euler(0, 0, zEulerAngle);
    }
}
