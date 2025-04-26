using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using MonoMod.RuntimeDetour;
using MonoMod.Utils;
using System.Reflection;

namespace Mod;
public class SlipperyCover
{
    public static void Start()
    {
        new Hook(
            typeof(FlippableCover).GetMethod("Start", BindingFlags.Instance | BindingFlags.NonPublic),
            typeof(SlipperyCover).GetMethod("HookFlippableCoverStart", BindingFlags.Static | BindingFlags.Public)
        );
    }

    public static void HookFlippableCoverStart(Action<FlippableCover> orig, FlippableCover self)
    {
        orig(self);
        self.DamageReceivedOnSlide = 0f;
    }
}