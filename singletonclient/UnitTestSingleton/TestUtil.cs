﻿/*
 * Copyright 2020-2021 VMware, Inc.
 * SPDX-License-Identifier: EPL-2.0
 */

using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json.Linq;
using SingletonClient;
using SingletonClient.Implementation;
using static SingletonClient.Implementation.SingletonUtil;

namespace UnitTestSingleton
{
    [TestClass]
    public class TestUtil
    {
        [TestMethod]
        public void TestSingletonUtil()
        {
            string status;
            string text = BaseIo.obj().HttpGet("11.22.33", null, 0, out status);
            Assert.AreEqual(string.IsNullOrEmpty(text), true);

            Assert.AreEqual(SingletonUtil.CheckResponseValid(null, null), ResponseStatus.NetFail);

            byte[] bytes = { 0xef, 0xbb, 0xbf, 0x31 };
            text = SingletonUtil.ConvertToText(bytes);
            Assert.AreEqual(text, "1");
            byte[] bytes2 = { 0xef, 0x31 };
            text = SingletonUtil.ConvertToText(bytes2);

            SingletonClientManager mgr = (SingletonClientManager)I18N.GetExtension();
            Assert.AreEqual(mgr.GetRelease(null), null);

            ICacheManager tempCache = mgr.GetCacheManager("try");
            Assert.AreEqual(tempCache.GetType() != null, true);
        }
    }
}
