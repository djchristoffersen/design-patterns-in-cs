using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace Wincubate.MementoExamples
{
    class GuestsViewModel : ObservableCollection<Guest>
    {
        private class GuestsViewModelMemento : IMemento
        {
            public object State { get; }

            public GuestsViewModelMemento( IEnumerable<Guest> guests )
            {
                State = guests.ToArray();
            }
        }

        public IMemento Memento
        {
            get => new GuestsViewModelMemento(Items);
            set
            {
                ClearItems();
                foreach( Guest g in value.State as IEnumerable<Guest> )
                {
                    Add(g);
                }
            }
        }
    }
}