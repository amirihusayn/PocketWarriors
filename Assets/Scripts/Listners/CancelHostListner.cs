﻿using UnityEngine;

public class CancelHostListner : ListnerPrototype
{
    // Fields________________________________________________________
    [SerializeField] private CustomNetworkDiscovery networkDiscovery;

    // Methods_____________________________________________________
    protected override void OnClickListner()
    {
        networkDiscovery.ListenBradcasts();
    }
}
