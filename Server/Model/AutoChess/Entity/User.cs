﻿using ETModel;
using MongoDB.Bson.Serialization.Attributes;

namespace ETHotfix
{
    [BsonIgnoreExtraElements]
    public partial class User : Entity
    {

    }
}