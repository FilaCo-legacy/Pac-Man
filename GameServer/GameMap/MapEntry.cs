using System.Collections;
using System.Collections.Generic;
using GameServer.GameObjects;

namespace GameServer.GameMap
{
    public class MapEntry : IEnumerable<GameObjectCode>
    {
        private readonly Stack<GameObjectCode> _content;

        public MapEntry()
        {
            _content = new Stack<GameObjectCode>();
            _content.Push(GameObjectCode.Void);
        }

        public void Push(GameObjectCode code)
        {
            _content.Push(code);
        }

        public void Pop()
        {
            _content.Pop();
        }

        public GameObjectCode Peek()
        {
            return _content.Peek();
        }

        public IEnumerator<GameObjectCode> GetEnumerator()
        {
            return _content.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}