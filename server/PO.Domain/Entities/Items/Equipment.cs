using System;
using PO.Domain.Entities.Enums;

namespace PO.Domain.Entities.Items;

public class Equipment : Item
{
    public EquipmentType Type { get; set; }
}
