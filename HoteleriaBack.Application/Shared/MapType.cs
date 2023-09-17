using HoteleriaBack.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HoteleriaBack.Application.Shared
{
    public class MapType
    {

        public string MapRoomType(RoomType type) => type switch
        {
            RoomType.Individual => "Individual",
            RoomType.Twin => "Doble",
            RoomType.Matrimonial => "Matrimonial",
            RoomType.Family => "Familiar",
            _ => throw new Exception("Habitación no existente")
        };
    }
}
