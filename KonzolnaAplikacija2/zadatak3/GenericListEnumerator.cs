using System.Collections;

namespace zadatak3
{
    internal class GenericListEnumerator<X> : IEnumerator
    {
        private GenericList<X> genericList;

        public GenericListEnumerator(GenericList<X> genericList)
        {
            this.genericList = genericList;
        }

        public object Current => throw new System.NotImplementedException();

        public bool MoveNext()
        {
            throw new System.NotImplementedException();
        }

        public void Reset()
        {
            throw new System.NotImplementedException();
        }
    }
}