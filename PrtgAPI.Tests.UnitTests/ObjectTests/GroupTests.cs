﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PrtgAPI.Tests.UnitTests.ObjectTests.Items;
using PrtgAPI.Tests.UnitTests.ObjectTests.Responses;

namespace PrtgAPI.Tests.UnitTests.ObjectTests
{
    [TestClass]
    public class GroupTests : StreamableObjectTests<Group, GroupItem, GroupResponse>
    {
        [TestMethod]
        public void Group_CanDeserialize() => Object_CanDeserialize();

        [TestMethod]
        public async Task Group_CanDeserializeAsync() => await Object_CanDeserializeAsync();

        [TestMethod]
        public void Group_CanStream_Ordered_FastestToSlowest() => Object_CanStream_Ordered_FastestToSlowest();

        [TestMethod]
        public void Group_GetObjectsOverloads_CanExecute() => Object_GetObjectsOverloads_CanExecute(
            (c1, c2, c3) => new List<Func<Property, object, object>> { c1.GetGroups, c2.GetGroupsAsync, c3.StreamGroups },
            (c1, c2, c3) => new List<Func<Property, FilterOperator, string, object>> { c1.GetGroups, c2.GetGroupsAsync, c3.StreamGroups },
            (c1, c2, c3) => new List<Func<SearchFilter[], object>> { c1.GetGroups, c2.GetGroupsAsync, c3.StreamGroups }
        );

        [TestMethod]
        public void Group_AllFields_HaveValues() => Object_AllFields_HaveValues();

        protected override List<Group> GetObjects(PrtgClient client) => client.GetGroups();

        protected override Task<List<Group>> GetObjectsAsync(PrtgClient client) => client.GetGroupsAsync();

        protected override IEnumerable<Group> Stream(PrtgClient client) => client.StreamGroups();

        public override GroupItem GetItem() => new GroupItem();

        protected override GroupResponse GetResponse(GroupItem[] items) => new GroupResponse(items);
    }
}
