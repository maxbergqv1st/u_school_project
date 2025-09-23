﻿using App;
// Recreate Learnpoint in the Terminal
// Logga in, Logga ut DONE
// Students, Teachers, Admin DONE
// Admin can create new accounts DONE
// Upload documents DONE
// Create schedules with events
// Teachers can grade exams DONE
// Students can upload files to exams DONE
// Admin can create courses
// ...
// hello git hub!!



List<CreateCourse> Course_List = new List<CreateCourse>();


List<UploadFile> file_list = new List<UploadFile>();
file_list.Add(new UploadFile{
      StudentName = "Max",
      FileName = "exam"
});


List<IUser> users = new List<IUser>();
users.Add(new Student("Max", "max", "pass", "mai-25-ha"));
users.Add(new Student("Hasse", "hasse", "pass", "mai-25-ma"));
users.Add(new Teacher("Zselyke", "zselyke", "pass"));
users.Add(new Admin("Baggen", "baggen", "pass"));



IUser? active_user = null;

bool running = true;



while(running)
{
      Console.Clear();

      if(active_user == null)
      {
            Console.WriteLine("Username: ");
            string username = Console.ReadLine();
            Console.Clear();
            
            Console.WriteLine("Password: ");
            string password = Console.ReadLine();
            Console.Clear();

            foreach(IUser user in users)
            {
                  if(user.TryLogin(username, password))
                  {
                        active_user = user;
                        break;
                  }
            }
      }
      else
      {
            Console.WriteLine("====== School System ======");

            if(active_user is Student s)
            {
                  Console.WriteLine("Welcome Student " + s.Name + " in class " + s.ClassRoom);
                  Console.WriteLine("[add] a file or document");
                  Console.WriteLine("[show] a file or document");
                  Console.WriteLine("[logout]");
                  switch(Console.ReadLine())
                  {
                        case "add" :
                              Console.Clear();
                              Console.WriteLine($"{s.Name} is uploading a file");
                              Console.Write("Add a file: ");
                              string filename = Console.ReadLine();
                              file_list.Add(new UploadFile
                              {
                                    StudentName = s.Name,
                                    FileName = filename,
                              });
                        break;

                        case "show" : 
                              Console.Clear();
                              Console.WriteLine($"===== Files {s.Name} ======\n");
                              var studentFiles = file_list.Where(f => f.StudentName == s.Name).ToList();

                              if(studentFiles.Count > 0)
                              {
                                    foreach(var file in studentFiles)
                                    {
                                          Console.WriteLine($"File owner {file.StudentName}: {file.FileName}.txt | Grade: {file.Grade ?? "Not graded"}");
                                    }
                              }
                              else
                              {
                                    Console.Write($"{s.Name} has no uploaded files");
                              }
                        break;
                  }
            }

            if(active_user is Teacher t)
            {
                  Console.WriteLine("Welcome Teacher: " + t.Name);
                  Console.WriteLine("[show] students files and grade");
                  Console.WriteLine("[logout]");

                  switch(Console.ReadLine())
                  {
                        case "show" : 
                              Console.Clear();
                              Console.WriteLine($"===== Files students ======\n");
                              foreach(var file in file_list)
                              {
                                    Console.WriteLine($"File owner {file.StudentName}: {file.FileName}.txt | Grade: {file.Grade ?? "Not graded"}");
                              }
                              Console.WriteLine("Grade a exam or file: ");
                              string GradeFile = Console.ReadLine();
                              var matchingFiles = file_list.Where(f => f.FileName == GradeFile).ToList();
                              if(matchingFiles.Count > 0)
                              {
                                    Console.Write("Grade the exam with mvg / vg / ig : ");
                                    string GradeOutput = Console.ReadLine();
                                    foreach (var file in matchingFiles)
                                    {
                                          file.Grade = GradeOutput;
                                    }

                                    Console.WriteLine("File(s) graded successfully!");
                                    Console.ReadKey();
                              }
                              else
                              {
                                    Console.WriteLine("invalid option... unable to grade the file...");
                                    Console.ReadKey();
                              }
                        break;
                  }
            }

            if(active_user is Admin a)
            {
                  Console.WriteLine("Welcome Admin " + a.Name);
                  Console.WriteLine("[add new account]");
                  Console.WriteLine("[logout]");
                  switch(Console.ReadLine())
                  {
                        case "add" :
                              Console.Clear();
                              Console.Write("Student / Teacher: ");
                              string type = Console.ReadLine();
                              Console.Clear();
                              Console.Write("Name: ");
                              string name = Console.ReadLine();
                              Console.Clear();
                              Console.Write("Username: ");
                              string username = Console.ReadLine();
                              Console.Clear();
                              Console.Write("Password:");
                              string password = Console.ReadLine();
                              Console.Clear();
                              Console.Write("ClassRoom:");
                              string classroom = Console.ReadLine();
                              if(type == "Teacher")
                              {
                                    Console.WriteLine("Teacher account successfully created... ");
                                    users.Add(new Teacher(name, username, password));
                              }
                              else if(type == "Student")
                              {
                                    Console.WriteLine("Student account successfully created... ");
                                    users.Add(new Student(name, username, password, classroom));
                              }
                              else
                              {
                                    Console.Write("invalid option, creating account failed...");
                              }

                              
                        break;
                  }
            }

            
            switch(Console.ReadLine())
            {
                  case "logout" : 
                        active_user  = null;
                  break;
            }
      }
}
