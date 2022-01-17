using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ITrigger<TPayload>
{
    IObservable<TPayload> TriggerObservable { get; }
}
