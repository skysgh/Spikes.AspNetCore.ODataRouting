﻿using Spikes.AspNetCore.ODataRouting.Models.ModuleA;
using System.Collections.ObjectModel;

namespace Spikes.AspNetCore.ODataRouting.Models.ModuleB
{
    // This is a model introduced by 
    // the second EDM model
    // that in turn references a child
    // model from the first EDM...
    // Lets see if we can get it to work
    public class SomePluginModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        // Collection of base module models
        // that don't know about this plugin
        // (probably would need an indrection object to pull 
        // it off in real life, but for now...)
        public ICollection<SomeBaseParentModel> SubChildren
        {
            get => _children;
            set => _children = value;
        }
        ICollection<SomeBaseParentModel> _children =
            new Collection<SomeBaseParentModel>();
    }
}
