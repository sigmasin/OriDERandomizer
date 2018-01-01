using System;
using Sein.World;
using UnityEngine;

// Token: 0x02000989 RID: 2441
public class SeinWorldStateCondition : Condition
{
    // Token: 0x0600357A RID: 13690
    public override bool Validate(IContext context)
    {
        switch (this.State)
        {
            case WorldState.WaterPurified:
                if (this.overrideEvent == SeinWorldStateCondition.OverrideEvents.None)
                {
                    return Events.WaterPurified == this.IsTrue;
                }
                if (this.overrideEvent == SeinWorldStateCondition.OverrideEvents.GinsoDoor)
                {
                    return false;
                }
                if (this.overrideEvent == SeinWorldStateCondition.OverrideEvents.WaterEscapeExit)
                {
                    this.surfaceColliders.SetActive(Events.WarmthReturned);
                    this.blockingWall.SetActive(Events.WarmthReturned);
                    if (Events.WarmthReturned)
                    {
                        return Events.WarmthReturned == this.IsTrue;
                    }
                    return Events.WaterPurified == this.IsTrue;
                }
                else
                {
                    if (this.overrideEvent == SeinWorldStateCondition.OverrideEvents.FinishEscapeTrigger)
                    {
                        return Events.WarmthReturned;
                    }
                    return Events.WaterPurified == this.IsTrue;
                }
                break;
            case WorldState.GumoFree:
                return Events.GumoFree == this.IsTrue;
            case WorldState.SpiritTreeReached:
                return Events.SpiritTreeReached == this.IsTrue;
            case WorldState.GinsoTreeKey:
                return Keys.GinsoTree == this.IsTrue;
            case WorldState.WindRestored:
                return Randomizer.WindRestored() == this.IsTrue;
            case WorldState.GravityActivated:
                return Events.GravityActivated == this.IsTrue;
            case WorldState.MistLifted:
                return Events.MistLifted == this.IsTrue;
            case WorldState.ForlornRuinsKey:
                return Keys.ForlornRuins == this.IsTrue;
            case WorldState.MountHoruKey:
                return Keys.MountHoru == this.IsTrue;
            case WorldState.WarmthReturned:
                return Events.WarmthReturned == this.IsTrue;
            case WorldState.DarknessLifted:
                return Events.DarknessLifted == this.IsTrue;
        }
        return false;
    }

    // Token: 0x0600357B RID: 13691
    private void Awake()
    {
        if (base.gameObject.name == "openingGinsoTree")
        {
            this.overrideEvent = SeinWorldStateCondition.OverrideEvents.GinsoDoor;
            return;
        }
        if (base.gameObject.name == "artAfter")
        {
            Transform expr_46 = base.transform.FindChild("artAfter");
            Transform transform = expr_46.FindChild("surfaceColliders");
            Transform transform2 = expr_46.FindChild("blockingWall");
            if (transform && transform2)
            {
                this.overrideEvent = SeinWorldStateCondition.OverrideEvents.WaterEscapeExit;
                this.surfaceColliders = transform.gameObject;
                this.blockingWall = transform2.gameObject;
                return;
            }
        }
        else
        {
            if (base.gameObject.name == "artBefore" && base.transform.parent && base.transform.parent.name == "ginsoTreeWaterRisingEnd")
            {
                this.overrideEvent = SeinWorldStateCondition.OverrideEvents.WaterEscapeExit;
                return;
            }
            if (base.name == "objectiveSetupTrigger" && base.transform.parent && base.transform.parent.name == "*objectiveSetup" && base.transform.parent.parent && base.transform.parent.parent.name == "thornfeltSwampActTwoStart")
            {
                this.overrideEvent = SeinWorldStateCondition.OverrideEvents.FinishEscapeTrigger;
                return;
            }
            if (base.name == "musiczones" && (base.transform.Find("musicZoneDuringRising") != null || (base.transform.parent && base.transform.parent.name == "ginsoTreeWaterRisingEnd")))
            {
                this.overrideEvent = SeinWorldStateCondition.OverrideEvents.FinishEscapeTrigger;
                return;
            }
            if (base.name == "activator")
            {
                if (base.transform.childCount == 1 && base.transform.GetChild(0).name == "container" && base.transform.GetChild(0).childCount == 1 && base.transform.GetChild(0).GetChild(0).name == "musicZoneHeartWaterRising")
                {
                    this.overrideEvent = SeinWorldStateCondition.OverrideEvents.FinishEscapeTrigger;
                    return;
                }
                if (base.transform.childCount == 1 && base.transform.GetChild(0).name == "musicZoneWaterCleansed")
                {
                    this.overrideEvent = SeinWorldStateCondition.OverrideEvents.FinishEscapeTrigger;
                    for (int i = 0; i < base.transform.parent.childCount; i++)
                    {
                        Transform child = base.transform.parent.GetChild(i);
                        if (child != base.transform && child.name == "activator")
                        {
                            this.musicZoneHeartWaterRising = child.GetChild(0).GetChild(0).gameObject;
                            return;
                        }
                    }
                    return;
                }
                if (base.transform.parent && base.transform.parent.name == "restoringHeartWaterRising")
                {
                    this.overrideEvent = SeinWorldStateCondition.OverrideEvents.FinishEscapeTrigger;
                }
            }
        }
    }

    // Token: 0x04003008 RID: 12296
    public WorldState State;

    // Token: 0x04003009 RID: 12297
    public bool IsTrue = true;

    // Token: 0x0400300A RID: 12298
    private SeinWorldStateCondition.OverrideEvents overrideEvent;

    // Token: 0x0400300B RID: 12299
    private GameObject surfaceColliders;

    // Token: 0x0400300C RID: 12300
    private GameObject blockingWall;

    // Token: 0x0400300D RID: 12301
    private GameObject musicZoneHeartWaterRising;

    // Token: 0x0200098A RID: 2442
    private enum OverrideEvents
    {
        // Token: 0x0400300F RID: 12303
        None,
        // Token: 0x04003010 RID: 12304
        GinsoDoor,
        WaterEscapeExit,
        FinishEscapeTrigger
    }
}
