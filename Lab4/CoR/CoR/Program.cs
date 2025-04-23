using System;

namespace SupportSystem
{
    abstract class SupportHandler
    {
        protected SupportHandler _nextHandler;

        public void SetNext(SupportHandler nextHandler)
        {
            _nextHandler = nextHandler;
        }

        public abstract void HandleRequest(string request);
    }

    class Level1Support : SupportHandler
    {
        public override void HandleRequest(string request)
        {
            if (request == "Технічні питання")
            {
                Console.WriteLine("Підтримка 1 рівня: Вирішуємо базові технічні питання.");
            }
            else if (_nextHandler != null)
            {
                _nextHandler.HandleRequest(request);
            }
            else
            {
                Console.WriteLine("Запит не знайдено, будь ласка, спробуйте ще раз.");
            }
        }
    }

    class Level2Support : SupportHandler
    {
        public override void HandleRequest(string request)
        {
            if (request == "Акаунти та підписки")
            {
                Console.WriteLine("Підтримка 2 рівня: Допомагаємо з питаннями акаунтів і підписок.");
            }
            else if (_nextHandler != null)
            {
                _nextHandler.HandleRequest(request);
            }
            else
            {
                Console.WriteLine("Запит не знайдено, будь ласка, спробуйте ще раз.");
            }
        }
    }

    class Level3Support : SupportHandler
    {
        public override void HandleRequest(string request)
        {
            if (request == "Проблеми з оплатою")
            {
                Console.WriteLine("Підтримка 3 рівня: Допомагаємо з проблемами з оплатою.");
            }
            else if (_nextHandler != null)
            {
                _nextHandler.HandleRequest(request);
            }
            else
            {
                Console.WriteLine("Запит не знайдено, будь ласка, спробуйте ще раз.");
            }
        }
    }

    class Level4Support : SupportHandler
    {
        public override void HandleRequest(string request)
        {
            if (request == "Інші запити")
            {
                Console.WriteLine("Підтримка 4 рівня: Допомагаємо з іншими запитами.");
            }
            else if (_nextHandler != null)
            {
                _nextHandler.HandleRequest(request);
            }
            else
            {
                Console.WriteLine("Запит не знайдено, будь ласка, спробуйте ще раз.");
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            var level1 = new Level1Support();
            var level2 = new Level2Support();
            var level3 = new Level3Support();
            var level4 = new Level4Support();

            level1.SetNext(level2);
            level2.SetNext(level3);
            level3.SetNext(level4);

            string request;
            do
            {
                Console.WriteLine("Виберіть питання для підтримки:");
                Console.WriteLine("1. Технічні питання");
                Console.WriteLine("2. Акаунти та підписки");
                Console.WriteLine("3. Проблеми з оплатою");
                Console.WriteLine("4. Інші запити");
                Console.WriteLine("5. Вийти");

                request = Console.ReadLine();

                if (request == "5")
                    break;

                switch (request)
                {
                    case "1":
                        level1.HandleRequest("Технічні питання");
                        break;
                    case "2":
                        level1.HandleRequest("Акаунти та підписки");
                        break;
                    case "3":
                        level1.HandleRequest("Проблеми з оплатою");
                        break;
                    case "4":
                        level1.HandleRequest("Інші запити");
                        break;
                    default:
                        Console.WriteLine("Невірний вибір, спробуйте ще раз.");
                        break;
                }

            } while (true);
        }
    }
}
