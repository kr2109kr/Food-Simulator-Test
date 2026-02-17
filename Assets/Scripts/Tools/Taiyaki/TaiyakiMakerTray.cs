using NUnit.Framework;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaiyakiMakerTray : MonoBehaviour
{
    [SerializeField] private TaiyakiMaker _taiyakiMaker;
    private string part = "Tray";

    [SerializeField] private Taiyaki[] taiyakis = new Taiyaki[5];

    public void Interact()
    {
        //_taiyakiMaker.Interact(part, taiyakis[0]);
    }
}
