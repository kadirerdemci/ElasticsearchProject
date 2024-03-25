using System;
using ElasticProject.Data.Entity;
using Nest;

namespace ElasticProject.Data.Mapping
{
    public static class Mapping
    {
        public static CreateIndexDescriptor CitiesMapping(this CreateIndexDescriptor descriptor)
        {
            return descriptor.Map<Cities>(m => m.Properties(p => p
                .Keyword(k => k.Name(n => n.Id))
                .Date(d => d.Name(n => n.CreateDate))
                .Text(t => t.Name(n => n.City))
                .Text(t => t.Name(n => n.Region))
                .Text(t => t.Name(n => n.Population))
            ));
        }
    }
}
