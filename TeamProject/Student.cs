using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamProject
{
    public enum Education
    {
        Specialist,
        Bachelor,
        SecondEducation
    }
    internal class Student
    {
        private Person person;
        private Education education;
        private int groupNumber;
        private Exam[] exams;

        public Person Person
        {
            get { return person; }
            set { person = value; }
        }

        public Education Education
        {
            get { return education; }
            set { education = value; }
        }

        public int GroupNumber
        {
            get { return groupNumber; }
            set { groupNumber = value; }
        }

        public Exam[] Exams
        {
            get { return exams; }
            set { exams = value; }
        }

        public double AverageGrade
        {
            get
            {
                if (exams == null || exams.Length == 0)
                    return 0;

                double sum = 0;
                foreach (var exam in exams)
                {
                    sum += exam.Grade;
                }
                return sum / exams.Length;
            }
        }

        public bool this[Education education]
        {
            get { return this.education == education; }
        }

        public Student(Person person, Education education, int groupNumber)
        {
            this.person = person;
            this.education = education;
            this.groupNumber = groupNumber;
            this.exams = new Exam[0];
        }

        public Student()
        {
            this.person = new Person();
            this.education = Education.Bachelor;
            this.groupNumber = 0;
            this.exams = new Exam[0];
        }

        public void AddExams(params Exam[] newExams)
        {
            int oldLength = exams.Length;
            Array.Resize(ref exams, oldLength + newExams.Length);
            Array.Copy(newExams, 0, exams, oldLength, newExams.Length);
        }

        public override string ToString()
        {
            StringBuilder examsInfoBuilder = new StringBuilder();

            foreach (var exam in exams)
            {
                if (examsInfoBuilder.Length > 0)
                {
                    examsInfoBuilder.Append(", ");
                }
                examsInfoBuilder.Append(exam.ToString());
            }

            string examsInfo = examsInfoBuilder.ToString();

            return $"Человек: {person}, Форма обучения: {education}, Номер группы: {groupNumber}, Экзамены: [{examsInfo}]";
        }


        public string ToShortString()
        {
            return $"Человек: {person}, Форма обучения: {education}, Номер группы: {groupNumber}, Средний балл: {AverageGrade}";
        }
    }
}
