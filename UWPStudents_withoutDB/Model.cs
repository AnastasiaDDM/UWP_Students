using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace UWPStudents_withoutDB
{


    public class Group : INotifyPropertyChanged
    {
        private int _id;
        private string _name;

        public int Id { get => _id; set { _id = value; OnPropertyChanged(); } }
        public string Name { get => _name; set { _name = value; OnPropertyChanged(); } }
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }

    public class Student : INotifyPropertyChanged
    {
        private int _id;
        private string _fio;
        private float _score;
        private float _income;
        private Group _group;
        private int _groupId;

        public int GroupId { get => _groupId; set { _groupId = value; OnPropertyChanged(); } }

        public int Id { get => _id; set { _id = value; OnPropertyChanged(); } }
        public string Fio { get => _fio; set { _fio = value; OnPropertyChanged(); } }
        public float Score { get => _score; set { _score = value; OnPropertyChanged(); } }
        public float Income { get => _income; set { _income = value; OnPropertyChanged(); } }
        public Group Group { get => _group; set { _group = value; OnPropertyChanged(); } }


        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }

    public class GroupList : ObservableCollection<Group>
    {
        private bool IsLoad { get; set; } = false;
        public GroupList() : base()
        {

            IsLoad = true;
            using (var db = new ContextLocal())
            {
                if (!db.Groups.Any())
                {
                    db.Groups.Add(new Group { Id = 1, Name = "ИС-20-1_db" });
                    db.Groups.Add(new Group { Id = 2, Name = "ИС-20-2_db" });
                    db.Groups.Add(new Group { Id = 3, Name = "БИ-20-1_db" });
                    db.SaveChanges();
                }

                foreach (var item in db.Groups)
                {
                    Add(item);
                }
            }
            IsLoad = false;

            this.CollectionChanged += GroupList_CollectionChanged;
        }

        public static List<Group> GroupListforCombobox()
        {
            using (var db = new ContextLocal())
            {

                List<Group> groups = new List<Group>();
                if (!db.Groups.Any())
                {
                    db.Groups.Add(new Group { Id = 1, Name = "ИС-20-1_db" });
                    db.Groups.Add(new Group { Id = 2, Name = "ИС-20-2_db" });
                    db.Groups.Add(new Group { Id = 3, Name = "БИ-20-1_db" });
                    db.SaveChanges();
                }

                foreach (var item in db.Groups)
                {
                    groups.Add(item);
                }
                return groups;
            }
        }

        private void GroupList_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            switch (e.Action)
            {
                case System.Collections.Specialized.NotifyCollectionChangedAction.Add:
                    using (var db = new ContextLocal())
                    {
                        var s = new Group { Id = (e.NewItems[0] as Group).Id, Name = (e.NewItems[0] as Group).Name };
                        db.Groups.Add(s);
                        db.SaveChanges();
                    }

                    break;
                case System.Collections.Specialized.NotifyCollectionChangedAction.Remove:
                    using (var db = new ContextLocal())
                    {
                        var s = e.OldItems[0] as Group;
                        db.Groups.Remove(s);
                        db.SaveChanges();
                    }
                    break;
            }
        }

        public new void Add(Group group)
        {

            if (!IsLoad)
            {
                int n = 1;
                if (this.Count > 0)
                {
                    n = this.Max(t => t.Id) + 1;
                }
                group.Id = n;
                group.Name = "";
            }
            group.PropertyChanged += Group_PropertyChangedAsync;
            base.Add(group);
        }

        private async void Group_PropertyChangedAsync(object sender, PropertyChangedEventArgs e)
        {
            var s = sender as Group;
            if (!IsLoad)
            {
                using (var db = new ContextLocal())
                {
                    if (db.Groups.Any(x => x.Id == s.Id))
                    {
                        var us = db.Groups.FirstOrDefault(x => x.Id == s.Id);
                        us.Name = s.Name;
                        db.SaveChanges();
                    }
                }
                //  await new Windows.UI.Popups.MessageDialog(s.Age.ToString()).ShowAsync();
            }
        }
    }

    public class StudentList : ObservableCollection<Student>
    {
        public List<Group> Groups { get; set; } = GroupList.GroupListforCombobox();
        public static List<Group> Groups1 { get; set; } = GroupList.GroupListforCombobox();

        private bool IsLoad { get; set; } = false;

        public StudentList() : base()
        {

            IsLoad = true;
            using (var db = new ContextLocal())
            {
                if (!db.Students.Any())
                {
                    db.Students.Add(new Student { Id = 1, Fio = "Иванов ИИ", Score = 78, Income = 20000, GroupId = Groups[0].Id });
                    db.Students.Add(new Student { Id = 2, Fio = "Федоров ФФ", Score = 98, Income = 50000, GroupId = Groups[1].Id });
                    db.Students.Add(new Student { Id = 3, Fio = "Сидорова СС", Score = 80, Income = 63000, GroupId = Groups[2].Id });
                    db.SaveChanges();
                }

                foreach (var item in db.Students)
                {
                    Add(item);
                }
            }
            IsLoad = false;

            this.CollectionChanged += StudentList_CollectionChanged;
        }


        public static List<Student> StudentListRating(float minS= 12792)
        {
            using (var db = new ContextLocal())
            {

                List<Student> students = new List<Student>();
                if (db.Students.Any())
                {
                    List<Student> Allstudents = db.Students.ToList();

                    // Проверка переданного параметра мин. зарплаты

                    var min = 12792;
                    try
                    {
                        min = Convert.ToInt32(minS);
                    }
                    catch
                    {
                        min = 12792;
                    }


                    
                        
                    // Первая часть списка по доходу
                    List<Student> Firststudents = Allstudents.Where(s => s.Income < min * 2).OrderBy(s => s.Income).ToList();

                    // Вторая часть спсика по баллу
                    List<Student> Secondstudents = Allstudents.Where(s => s.Income >= min * 2).OrderByDescending(s => s.Score).ToList();

                    students.AddRange(Firststudents);
                    students.AddRange(Secondstudents);

                    foreach (var item in students)
                    {
                        // Заполнение группы студенту
                        GetGroup(item, Groups1);
                    }

                }

                return students;
            }
        }


        private void StudentList_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            switch (e.Action)
            {
                case System.Collections.Specialized.NotifyCollectionChangedAction.Add:
                    using (var db = new ContextLocal())
                    {
                        var s = new Student { Id = (e.NewItems[0] as Student).Id, GroupId = (e.NewItems[0] as Student).Group.Id };
                        db.Students.Add(s);
                        db.SaveChanges();
                    }

                    break;
                case System.Collections.Specialized.NotifyCollectionChangedAction.Remove:
                    using (var db = new ContextLocal())
                    {
                        var s = e.OldItems[0] as Student;
                        db.Students.Remove(s);
                        db.SaveChanges();
                    }
                    break;
            }
        }

        public new void Add(Student student)
        {

            if (!IsLoad)
            {
                int n = 1;
                if (this.Count > 0)
                {
                    n = this.Max(t => t.Id) + 1;
                }
                student.Id = n;
                student.Group = Groups[0];
                student.GroupId = Groups[0].Id;
                student.Fio = "";
            }
            student.PropertyChanged += Student_PropertyChangedAsync;
            student.Group = Groups.FirstOrDefault(x => x.Id == student.GroupId);
            base.Add(student);
           
        }


        public static void GetGroup(Student student, List<Group> groups)
        {

            student.Group = groups.FirstOrDefault(x => x.Id == student.GroupId);


        }


        private async void Student_PropertyChangedAsync(object sender, PropertyChangedEventArgs e)
        {
            var s = sender as Student;
            if (!IsLoad)
            {
                using (var db = new ContextLocal())
                {
                    if (db.Students.Any(x => x.Id == s.Id))
                    {
                        var us = db.Students.FirstOrDefault(x => x.Id == s.Id);
                        us.Fio = s.Fio;
                        us.Score = s.Score;
                        us.Income = s.Income;
                        us.GroupId = s.Group.Id;
                        db.SaveChanges();
                    }
                }
                //  await new Windows.UI.Popups.MessageDialog(s.Age.ToString()).ShowAsync();
            }
        }
    }

}
