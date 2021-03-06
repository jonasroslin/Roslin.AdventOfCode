﻿using System.Collections.Generic;
using System.Linq;

namespace Roslin.AdventOfCode.Day5
{
    public class CheckIfWordIsNice
    {
        private readonly List<IRule> _rules;

        public CheckIfWordIsNice(List<IRule> rules)
        {
            _rules = rules;
        }

        public bool IsNice(string word, IRule overrideAllRule)
        {
            var isNice = _rules.All(rule => rule.IsNice(word));
            var nice = overrideAllRule.IsNice(word);

            return nice && isNice;
        }

        public bool IsNice(string word)
        {
            foreach (var rule in _rules)
            {
                var nice = rule.IsNice(word);
                if (nice == false)
                    return false;
            }

            return true;
            //var isNice = _rules.All(rule => rule.IsNice(word));
            //return isNice;
        }
    }
}