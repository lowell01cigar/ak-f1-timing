// Copyright 2009 Andy Kernahan
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
//     http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.

using System;
using Xunit;

namespace AK.F1.Timing.Messages.Driver
{
    public class SetDriverLapTimeMessageTest : MessageTestBase<SetDriverLapTimeMessage>
    {
        [Fact]
        public override void can_visit()
        {
            var message = CreateTestMessage();
            var visitor = CreateMockMessageVisitor();

            visitor.Setup(x => x.Visit(message));
            message.Accept(visitor.Object);
            visitor.VerifyAll();
        }

        [Fact]
        public void ctor_throw_if_lap_time_is_null()
        {
            Assert.Throws<ArgumentNullException>(() => { new SetDriverLapTimeMessage(1, null); });
        }

        protected override void AssertEqualsTestMessage(SetDriverLapTimeMessage message)
        {
            Assert.Equal(1, message.DriverId);
            Assert.Equal(PostedTime, message.LapTime);
        }

        protected override SetDriverLapTimeMessage CreateTestMessage()
        {
            return new SetDriverLapTimeMessage(1, PostedTime);
        }
    }
}