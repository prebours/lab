﻿using System;
using System.Collections.Generic;
using System.Text;

namespace NUnit.Framework.Constraints.Operators
{
    public abstract class BaseStaticEqualityOperatorProvider<T> : IStaticEqualityOperatorProvider where T : class
    {
        private void CheckParameter(object parameter)
        {
            if (parameter != null && !(parameter is T))
            {
                throw new ArgumentException();
            }
        }

        private void CheckParameters(object lhs, object rhs)
        {
            CheckParameter(lhs);
            CheckParameter(rhs);
        }

        bool IStaticEqualityOperatorProvider.EvaluateStaticEqualEqualOperator(object lhs, object rhs)
        {
            CheckParameters(lhs, rhs);
            return EvaluateStaticEqualEqualOperator(lhs as T, rhs as T);
        }

        bool IStaticEqualityOperatorProvider.EvaluateStaticNotEqualOperator(object lhs, object rhs)
        {
            CheckParameters(lhs, rhs);
            return EvaluateStaticNotEqualOperator(lhs as T, rhs as T);
        }

        public abstract bool EvaluateStaticEqualEqualOperator(T lhs, T rhs);
        public abstract bool EvaluateStaticNotEqualOperator(T lhs, T rhs);

    }
   
}
