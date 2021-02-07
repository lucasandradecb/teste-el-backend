﻿using Flunt.Notifications;
using System;

namespace Teste.El.Backend.Domain.Entities.Core
{
    public abstract class Entity : Notifiable
    {
        private Guid _id;
        public virtual Guid Id
        {
            get => _id;
            protected set => _id = value;
        }

        protected Entity() => Id = Guid.NewGuid();
    }
}
