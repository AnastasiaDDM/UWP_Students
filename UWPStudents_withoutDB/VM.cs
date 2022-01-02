using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace UWPStudents_withoutDB
{
    //internal class VM
    //{
    //}


    abstract class VM_StudentCommand : ICommand
    {
        protected VM_Student VM_Student;

        public VM_StudentCommand(VM_Student vM_Student)
        {
            VM_Student = vM_Student;
        }
        public event EventHandler CanExecuteChanged;

        public abstract bool CanExecute(object parameter);

        public abstract void Execute(object parameter);

    }

    class AddStudent : VM_StudentCommand
    {
        public AddStudent(VM_Student vM_Student) : base(vM_Student)
        {
        }
        public override bool CanExecute(object parameter)
        {
            return true;
        }

        public override void Execute(object parameter)
        {
            var s = new Student();
            VM_Student.Students.Add(s);
            VM_Student.SelectedStudent = s;
        }
    }

    class DeleteStudent : VM_StudentCommand
    {
        public DeleteStudent(VM_Student vM_Student) : base(vM_Student)
        {
        }

        public override bool CanExecute(object parameter)
        {
            return true;
        }

        public override void Execute(object parameter)
        {
            VM_Student.Students.Remove(VM_Student.SelectedStudent);
        }
    }

    class RatingStudents : VM_StudentCommand
    {

        public RatingStudents(VM_Student vM_Student) : base(vM_Student)
        {
            
        }
        public override bool CanExecute(object parameter)
        {
            return true;
        }

        public override void Execute(object parameter)
        {
            VM_Student.StudentsRating = StudentList.StudentListRating(VM_Student.MinSalary);
        }
    }


    public class VM_Student : INotifyPropertyChanged
    {
        private StudentList _students;
        private Student _selectedStudent;
        private ICommand _add;
        private ICommand _del;

        private ICommand _rating;
        public List<Student> _studentsrating;
        private float _minSalary;

        public StudentList Students { get => _students; set { _students = value; OnPropertyChanged(); } }

        public List<Student> StudentsRating { get => _studentsrating; set { _studentsrating = value; OnPropertyChanged(); } }
        public float MinSalary { get => _minSalary; set { _minSalary = value; OnPropertyChanged(); } }

        public Student SelectedStudent { get => _selectedStudent; set { _selectedStudent = value; OnPropertyChanged(); } }

        public ICommand Add
        {
            get
            {
                if (_add == null)
                {
                    _add = new AddStudent(this);
                }
                return _add;
            }
        }

        public ICommand Del
        {
            get
            {
                if (_del == null)
                {
                    _del = new DeleteStudent(this);
                }
                return _del;
            }
        }

        public ICommand Rating
        {
            get
            {
                if (_rating == null)
                {
                    
                    _rating = new RatingStudents(this);
                }
                return _rating;
            }
        }

        public VM_Student()
        {
            Students = new StudentList();
        }


        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }







    abstract class VM_GroupCommand : ICommand
    {
        protected VM_Group VM_Group;

        public VM_GroupCommand(VM_Group vM_Group)
        {
            VM_Group = vM_Group;
        }
        public event EventHandler CanExecuteChanged;

        public abstract bool CanExecute(object parameter);

        public abstract void Execute(object parameter);

    }

    class AddGroup : VM_GroupCommand
    {
        public AddGroup(VM_Group vM_Group) : base(vM_Group)
        {
        }
        public override bool CanExecute(object parameter)
        {
            return true;
        }

        public override void Execute(object parameter)
        {
            var s = new Group();
            VM_Group.Groups.Add(s);
            VM_Group.SelectedGroup = s;
        }
    }

    class DeleteGroup : VM_GroupCommand
    {
        public DeleteGroup(VM_Group vM_Group) : base(vM_Group)
        {
        }

        public override bool CanExecute(object parameter)
        {
            return true;
        }

        public override void Execute(object parameter)
        {
            VM_Group.Groups.Remove(VM_Group.SelectedGroup);
        }
    }


    public class VM_Group : INotifyPropertyChanged
    {
        private GroupList _groups;
        private Group _selectedGroup;
        private ICommand _add;
        private ICommand _del;

        public GroupList Groups { get => _groups; set { _groups = value; OnPropertyChanged(); } }

        public Group SelectedGroup { get => _selectedGroup; set { _selectedGroup = value; OnPropertyChanged(); } }

        public ICommand Add
        {
            get
            {
                if (_add == null)
                {
                    _add = new AddGroup(this);
                }
                return _add;
            }
        }

        public ICommand Del
        {
            get
            {
                if (_del == null)
                {
                    _del = new DeleteGroup(this);
                }
                return _del;
            }
        }


        public VM_Group()
        {
            Groups = new GroupList();
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }

}
