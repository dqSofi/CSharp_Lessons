using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAddressbookTests
{
    public class GroupData :IEquatable<GroupData>,IComparable<GroupData>
    {
        private string name;
        private string header;
        private string footer;

        public GroupData (string name)
        {
            this.name = name;
        }
        public String Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
            }
        }
        public String Header
        {
            get
            {
                return header;
            }
            set
            {
                header = value;
            }
        }
        public String Footer
        {
            get
            {
                return footer;
            }
            set
            {
                footer = value;
            }
        }

        public bool Equals(GroupData other)
        {
            if (Object.ReferenceEquals(other, null))//это стандартная проверка
            {
                return false;
            }
            if (Object.ReferenceEquals(this, other))//вторая стандартная проверка
            {
                return true;
            }
            return Name == other.Name;
        }

        public override int GetHashCode() // для оптимизации, не совпали хэш коды - точно разные объекты,
                                //совпали - можно и в equals сравнить
        {
            //return 0; без оптимизации, всегда смотреть в equals
            return Name.GetHashCode();
        }

        public override string ToString()
        {
            return "name="+Name;
        }

        // CompareTo returns 
        //1 - если текущий объект this больше по нашему правилу сравнения
        //0 - если объекты равны
        //-1 - если this меньше чем other


        public int CompareTo(GroupData other)
        {
            if (object.ReferenceEquals(other, null))
            {
                return 1;
            }
            return Name.CompareTo(other.Name);
        }
    }
}
