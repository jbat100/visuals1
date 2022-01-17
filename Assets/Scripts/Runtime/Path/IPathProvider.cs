using PathCreation;
using UnityEngine;

namespace UnityTemplateProjects.Path
{
    public interface IPathProvider
    {
        VertexPath VertexPath { get; }
    }
}