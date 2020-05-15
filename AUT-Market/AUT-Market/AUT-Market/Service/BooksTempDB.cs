using AUT_Market.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace AUT_Market.Service
{
    class BooksTempDB
    {
        public List<TestBooks> GetBooks()
        {

            return new List<TestBooks>
            {
                 new TestBooks
                {
                    //WishList = true,
                    imageUrl = "https://d1w7fb2mkkr3kw.cloudfront.net/assets/images/book/lrg/9781/1188/9781118881170.jpg",
                    title = "The Global airline industry",
                    price = 120.00,
                    courseCode = "AVA101",
                    faculty = "Aviation",
                    BookDesc = "Extensively revised and updated edition of the bestselling textbook, provides an overview of recent global airline industry evolution and future challenges" +
                    " * Examines the perspectives of the many stakeholders in the global airline industry, including airlines, airports, air traffic services, governments, labor unions, in addition to passengers " +
                    "* Describes how these different players have contributed to the evolution of competition in the global airline industry, and the implications for its future evolution " +
                    "* Includes many facets of the airline industry not covered elsewhere in any single book, for example, safety and security, labor relations and environmental impacts of aviation " +
                    "* Highlights recent developments such as changing airline business models, growth of emerging airlines, plans for modernizing air traffic management, and opportunities offered by new information technologies for ticket distribution " +
                    "* Provides detailed data on airline performance and economics updated through 2013"
                },

                 new TestBooks
                {
                    //WishList = true,
                    imageUrl = "https://d1w7fb2mkkr3kw.cloudfront.net/assets/images/book/lrg/9780/1988/9780198842453.jpg",
                    title = "Oxford Textbook of Anaesthesia",
                    price = 220.00,
                    courseCode = "HS101",
                    faculty = "Health Sicence",
                    BookDesc = "This definitive resource from the eminent Oxford Textbooks series, the Oxford Textbook of Anaesthesia addresses the fundamental principles, underpinning sciences and the full spectrum of clinical practice. " +
                    "It brings together the most pertinent research from on-going scientific endeavours with practical guidance and a passion to provide the very best clinical care to patients\n " +
                    "This comprehensive work covers all aspects of anaesthesia; volume one addresses the fundamental principles and the basic sciences whose understanding is required for a logical, effective and evidence-based approach to practice. " +
                    "Volume two focuses on the clinical aspects of anaesthesia, including those aspects of intensive care and pain medicine that are required by all general anaesthetists as well as sections dedicated to procedures, surgical specialities, " +
                    "paediatrics, the conduct of anaesthesia outside the theatre, and concurrent disease."
                },

                 new TestBooks
                {
                    //WishList = false,
                    imageUrl = "https://d1w7fb2mkkr3kw.cloudfront.net/assets/images/book/lrg/9781/1387/9781138708976.jpg",
                    title = "Fundamentals of International Aviation",
                    price = 223.80,
                    courseCode = "AVA102",
                    faculty = "Aviation",
                    BookDesc = "International aviation is a massive and complex industry that is crucial to our global economy and way of life.\n\n Fundamentals of International Aviation, designed for the next generation of aviation professionals, " +
                    "flips the traditional approach to aviation education.Instead of focusing on one career in one country, it has been designed to introduce the aviation industry on a global scale with a broad view of all the interconnected professional groups. " +
                    "Therefore, this is an appropriate introductory book for any aviation career(including aviation regulators, maintenance engineers, pilots, flight attendants, airline managers, dispatchers, air traffic controllers, and airport managers among many others).\n\n" +
                    "Each chapter of this text introduces a different cross - section of the industry, from air law to operations, security to remotely - piloted aircraft(drones).A variety of learning tools are built into each section, " +
                    "including case studies that describe an aviation accident related to the content of each chapter."
                },

                 new TestBooks
                {
                    //WishList = false,
                    imageUrl = "https://d1w7fb2mkkr3kw.cloudfront.net/assets/images/book/lrg/9780/0781/9780078112911.jpg",
                    title = "Global Business Today",
                    price = 199.99,
                    courseCode = "BUS101",
                    faculty = "Business",
                    BookDesc = "International aviation is a massive and complex industry that is crucial to our global economy and way of life.\n\n Fundamentals of International Aviation, designed for the next generation of aviation professionals, " +
                    "flips the traditional approach to aviation education.Instead of focusing on one career in one country, it has been designed to introduce the aviation industry on a global scale with a broad view of all the interconnected professional groups. " +
                    "Therefore, this is an appropriate introductory book for any aviation career(including aviation regulators, maintenance engineers, pilots, flight attendants, airline managers, dispatchers, air traffic controllers, and airport managers among many others).\n\n" +
                    "Each chapter of this text introduces a different cross - section of the industry, from air law to operations, security to remotely - piloted aircraft(drones).A variety of learning tools are built into each section, " +
                    "including case studies that describe an aviation accident related to the content of each chapter."
                },

                 new TestBooks
                {
                    //WishList = false,
                    imageUrl = "https://d1w7fb2mkkr3kw.cloudfront.net/assets/images/book/mid/9780/1988/9780198855439.jpg",
                    title = "Oxford textbook of Critical Care",
                    price = 65.00,
                    courseCode = "BUS101",
                    faculty = "Health Science",
                    BookDesc = "Now in paperback, the second edition of the Oxford Textbook of Critical Care is a comprehensive multi-disciplinary text covering all aspects of adult intensive care management." +
                    " Uniquely this text takes a problem-orientated approach providing a key resource for daily clinical issues in the intensive care unit.\n\n " +
                    "The text is organized into short topics allowing readers to rapidly access authoritative information on specific clinical problems. Each topic refers to basic physiological principles and provides " +
                    "up-to-date treatment advice supported by references to the most vital literature. Where international differences exist in clinical practice," +
                    " authors cover alternative views. Key messages summarise each topic in order to aid quick review and decision making.\n\n Edited and written by an international group of recognized experts from many disciplines," +
                    " the second edition of the Oxford Textbook of Critical Careprovides an up-to-date reference that is relevant for intensive care units " +
                    "and emergency departments globally.This volume is the definitive text for all health care providers, including physicians, nurses, respiratory therapists, and other allied health professionals who take care of critically ill patients."
                },

                 new TestBooks
                {
                    //WishList = false,
                    imageUrl = "https://d1w7fb2mkkr3kw.cloudfront.net/assets/images/book/mid/9781/3375/9781337561914.jpg",
                    title = "Invitation To Computer Science",
                    price = 142.00,
                    courseCode = "COMP101",
                    faculty = "Computer Science",
                    BookDesc = "Gain a contemporary overview of today's computer science with the best-selling INVITATION TO COMPUTER SCIENCE, 8E. This flexible, non-language-specific book uses an algorithm-centered approach that's ideal for your first introduction to computer science." +
                    " Measurable learning objectives and a clear hierarchy help introduce algorithms, hardware, virtual machines, software development, applications, and social issues. Exercises, practice problems, " +
                    "and feature boxes emphasize real-life context as well as the latest material on privacy, drones, cloud computing, and net neutrality. Optional online language modules for C++, Java, Python, C#, and Ada let you learn a programming language. " +
                    "MindTap is available with online study tools, a digital Lab Manual and lab software with 20 laboratory projects. Hands-on activities enable you to truly experience the fundamentals of today's computer science."
                },

                 new TestBooks
                {
                    //WishList = true,
                    imageUrl = "https://d1w7fb2mkkr3kw.cloudfront.net/assets/images/book/mid/9788/1833/9788183334709.jpg",
                    title = "Computer Science with C++",
                    price = 299.00,
                    courseCode = "COMP102",
                    faculty = "Computer Science",
                    BookDesc = "The book has a student-friendly approach and lucid style as all computer programs are written with lots of familiar abbreviations, comments and output Windows. All codes are compiled, executed and are error-free. " +
                    "One of the salient features of the approach used here is that students will be able to read, modify and extend programs rather than designing and writing from scratch. " +
                    "Control structures have been will explained with the help of date flow diagrams. Each concept has been illustrated with the help of programs along with detailed explanation. " +
                    "Ctm (commit to memory) and points to Remember will help students to easily recall important terms and concepts"
                },

                 new TestBooks
                {
                    //WishList = true,
                    imageUrl = "https://d1w7fb2mkkr3kw.cloudfront.net/assets/images/book/mid/9781/4051/9781405168021.jpg",
                    title = "Engineering Project Managment",
                    price = 350.00,
                    courseCode = "ENG104",
                    faculty = "Enginerring",
                    BookDesc = "Engineering Project Management provides a clear description of the aims of project management, based on best practice, and discusses the theory and practice in relation to multi-disciplinary engineering projects," +
                    " both large and small, in the UK and overseas. The Third Edition takes account of the increase in joint ventures, project partnering, special project vehicles and other forms of collaborative working. " +
                    "The text has been extended to give more information on procurement, stakeholders and collaborative provision. For the first time this book now contains a chapter on the UK PRINCE2(r) " +
                    "project management methodology providing a unique insight into this increasingly popular approach. The expertise of the authors gained from their promotion of effective project management through a combination of professional experience, research," +
                    " consultancy, education and training should be beneficial to both students of project management and recently appointed or practising project managers. The material is appropriate to support Masters level teaching, MSc, MBA and MEng," +
                    " either by universities or others, action or distance learning courses and self learning programmes."
                },

                 new TestBooks
                {
                    //WishList = true,
                    imageUrl = "https://d1w7fb2mkkr3kw.cloudfront.net/assets/images/book/mid/9780/1987/9780198746690.jpg",
                    title = "Oxford Textbook of Medicine",
                    price = 1459.00,
                    courseCode = "MED101",
                    faculty = "Health Science",
                    BookDesc = "The Oxford Textbook of Medicine is the foremost international textbook of medicine. Unrivalled in its coverage of the scientific aspects and clinical practice of internal medicine and its subspecialties, " +
                    "it is a fixture in the offices and wards of physicians around the world, as well as being a key resource for medico-legal practitioners. Accessible digitally with regular updates, as well as in print, " +
                    "readers are provided with multiple avenues of access depending on their need and preference."
                },

                 new TestBooks
                {
                    //WishList = true,
                    imageUrl = "https://d1w7fb2mkkr3kw.cloudfront.net/assets/images/book/mid/9781/9355/9781935589679.jpg",
                    title = "Project Management",
                    price = 500.00,
                    courseCode = "POJ102",
                    faculty = "Information Technology",
                    BookDesc = "Having already sold more than 200,000 copies and helped generations of project managers navigate the ins and outs of every aspect of successful project management, " +
                    "this revised fifth edition of Fundamentals of Project Management remains the perfect resource for succeeding in this complex discipline that has changed greatly in recent years. " +
                    "Fully updated in accordance with the latest version of the Project Management Body of Knowledge (PMBOK (R)), this all-encompassing book contains new information and expanded coverage on topics including estimating; stakeholder management; " +
                    "procurement management; creating a communication plan; project closure; requirements for PMP certification; and much more. Readers will also learn how to:* Clarify project goals and objectives* " +
                    "Develop a work breakdown in structure* Create a project risk plan* Produce a realistic schedule* Manage change requests* Control and evaluate progress at every stageChock full of tools, techniques, examples, and instructive exercises, " +
                    "don't go one more day without equipping yourself with what PM World Journal calls \" . . . a great resource for helping a project manager or other team member to learn new tools and techniques or refresh their knowledge.\""
                },

            };
        }
    }
}
