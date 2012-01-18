﻿using System;
using System.Linq;

namespace Neo4jClient.Cypher
{
    public static class StartStep
    {
        public static ICypherQuery Start(this ICypherQuery query, string declaration, BoundPoint boundPoint, int[] ids)
        {
            var startText = string.Format("start {0}=", declaration);
            var parameters = new string[ids.Length];
            for (var i = 0; i < ids.Length; i++)
            {
                parameters[i] = string.Format("p{0}", i);
            }

            var newQuery = query.BuildStartById(string.Format("{0}{1}({2})", startText, boundPoint.ToString().ToLower(), String.Join(",", parameters)), ids);
            return newQuery;
        }

        public static ICypherQuery Start(this ICypherQuery query, string declaration, NodeReference<object>[] nodeReferences)
        {
            var startText = string.Format("start {0}=", declaration);
            var parameters = new string[nodeReferences.Length];
            for (var i = 0; i < nodeReferences.Length; i++)
            {
                parameters[i] = string.Format("p{0}", i);
            }

            var newQuery = query.BuildStartById(string.Format("{0}{1}({2})", startText, BoundPoint.Node.ToString().ToLower(),String.Join(",", parameters)), nodeReferences.Select(n => n.Id).ToArray());
            return newQuery;
        }

        public static ICypherQuery Start(this ICypherQuery query, string declaration, RelationshipReference[] relationships)
        {
            var startText = string.Format("start {0}=", declaration);
            var parameters = new string[relationships.Length];
            for (var i = 0; i < relationships.Length; i++)
            {
                parameters[i] = string.Format("p{0}", i);
            }

            var newQuery = query.BuildStartById(string.Format("{0}{1}({2})", startText, BoundPoint.Relationship.ToString().ToLower(),String.Join(",", parameters)), relationships.Select(r => r.Id).ToArray());
            return newQuery;
        }
    }
}