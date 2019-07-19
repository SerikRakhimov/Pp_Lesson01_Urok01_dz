using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pp_urok01_dz
{
    // Класс Создатель объявляет фабричный метод, который должен возвращать
    // объект класса Продукт. Подклассы Создателя обычно предоставляют
    // реализацию этого метода.
    abstract class Logistic
    {
        // Обратите внимание, что Создатель может также обеспечить
        // реализацию фабричного метода по умолчанию.
        public abstract IPaper GetPaper();

        // Также заметьте, что, несмотря на название, основная обязанность
        // Создателя не заключается в создании продуктов. Обычно он содержит
        // некоторую базовую бизнес-логику, которая основана  на объектах
        // Продуктов, возвращаемых фабричным методом.  Подклассы могут косвенно
        // изменять эту бизнес-логику, переопределяя фабричный метод и возвращая
        // из него другой тип продукта.
        public string MethodPrint()
        {
            // Вызываем фабричный метод, чтобы получить объект-продукт.
            IPaper product = GetPaper();
            // Далее, работаем с этим продуктом.
            string result = "Созданный принтер использует для печати бумагу "
                + product.ParerType();

            return result;
        }
    }

    // Конкретные Создатели переопределяют фабричный метод для того, чтобы
    // изменить тип результирующего продукта.
    class Canon : Logistic
    {
        // Обратите внимание, что сигнатура метода по-прежнему использует
        // тип абстрактного продукта, хотя  фактически из метода возвращается
        // конкретный продукт. Таким образом, Создатель может оставаться
        // независимым от конкретных классов продуктов.
        public override IPaper GetPaper()
        {
            return new Perl();
        }
    }

    class HP : Logistic
    {
        public override IPaper GetPaper()
        {
            return new Offset();
        }
    }

    // Интерфейс Продукта объявляет операции, которые должны выполнять все
    // конкретные продукты.
    public interface IPaper
    {
        string ParerType();
    }

    // Конкретные Продукты предоставляют различные реализации интерфейса
    // Продукта.
    class Perl : IPaper
    {
        public string ParerType()
        {
            return "Perl";
        }
    }

    class Offset : IPaper
    {
        public string ParerType()
        {
            return "Offset";
        }
    }

    class Client
    {
        public void Main()
        {
            Console.WriteLine("Canon");
            ClientCode(new Canon());

            Console.WriteLine("");

            Console.WriteLine("HP");
            ClientCode(new HP());
        }

        // Клиентский код работает с экземпляром конкретного создателя, хотя
        // и через его базовый интерфейс. Пока клиент продолжает работать с
        // создателем через базовый интерфейс, вы можете передать ему любой
        // подкласс создателя.
        public void ClientCode(Logistic creator)
        {
            // ...
            Console.WriteLine("Клиент: запущен метод MethodPrint()" +
                "\n" + creator.MethodPrint());
            // ...
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            new Client().Main();
            Console.ReadLine();
        }
    }

}
