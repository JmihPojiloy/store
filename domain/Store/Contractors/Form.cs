﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Contractors
{
    public class Form
    {
        public string UniqueCode { get; }

        public int OrderId { get; }

        public int Step { get; }

        public bool IsFinale { get; }

        public IReadOnlyList<Field> Fields { get; }

        public Form(string uniqueCode, int orderId, int step, bool isFinale, IReadOnlyList<Field> fields)
        {
            if (string.IsNullOrWhiteSpace(uniqueCode))
                throw new ArgumentException(nameof(uniqueCode));

            if (step < 1)
                throw new ArgumentOutOfRangeException(nameof(step));

            if (fields == null)
                throw new ArgumentNullException(nameof(fields));

            UniqueCode = uniqueCode;
            OrderId = orderId;
            Step = step;
            IsFinale = isFinale;
            Fields = fields.ToArray();
        }
    }
}
