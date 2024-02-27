using Microsoft.Practices.Prism.Commands;
using Microsoft.Practices.Prism.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ViewModel
{ // una clase base comúnmente utilizada para implementar la interfaz INotifyPropertyChanged. Esta interfaz es fundamental en el patrón MVVM (Model-View-ViewModel) 
    //INotifyPropertyChanged se utiliza para notificar a los enlaces de datos cuando cambian las propiedades de un objeto. Esto permite que la interfaz de usuario (la Vista) se actualice automáticamente cuando cambian los datos subyacentes (el Modelo).

    public class MainViewModel :NotificationObject //hacemo referencia ddls  una propieda pirvada y publica 
    {
        private int _numero1; //internamente 
        private int _numero2;
        private int _resultado;
        private ICommand sumarCommand; // Esto significa que puedes enlazar esta propiedad a un control de la interfaz de usuario en XAML y ejecutar una acción cuando se active ese control.



        public int Numero1
        {
            get { return _numero1; }
            set
            {
                /*
       comprueba si el nuevo valor es diferente del valor actual antes de asignarlo. Si son diferentes, se asigna el nuevo valor y se notifica a los enlaces de datos que la propiedad ha cambiado utilizando el método RaisePropertyChanged.
      */
                if (value ==_numero1) //1=1 ->1=2
                    return;
                _numero1 = value; //1
                RaisePropertyChanged(()=>Numero1); // Se utiliza para notificar a los enlaces de datos que una propiedad ha cambiado. Toma una expresión lambda que especifica la propiedad que ha cambiado(se visualiza en view)
            }

        }
        public int Numero2
        {
            get { return _numero2; }
            set
            {
                if (value == _numero2)
                    return;
                _numero2 = value;
                RaisePropertyChanged(() => Numero2); //se actualizo 
            }

        }
        public int Resultado
        {
            get { return _resultado; }
            set
            {
                if (value == _resultado)
                    return;
                _resultado = value;
                RaisePropertyChanged(() => Resultado); //se actualizo 
            }

        }

        public ICommand SumarCommand
        { //System.Windows.Input que define un contrato para representar un comando que puede ser ejecutado por un componente de la interfaz de usuario, como un botón, un menú o un elemento de lista.
            get
            {
                if (sumarCommand == null) //si la variable sumarCommand es null
                {
                    sumarCommand = new DelegateCommand(Sumar, () =>true); //ermite pasar acciones y predicados al constructor para definir el método que se ejecutará cuando se invoque el comando 
                } //método que se ejecutará cuando se active el comando SumarCommand
                return sumarCommand;
            }

            /*() => true: Este es el segundo argumento y representa un predicado que determina si el comando puede ejecutarse en su estado actual. 
             * Aquí, estamos utilizando una expresión lambda () => true, que siempre devuelve true. 
             * Esto significa que el comando siempre puede ejecutarse.*/
            }
             public void Sumar() {
                Resultado = Numero1 + Numero2; //punto de interrupcion para saber si hay un dato 
                    }

            public MainViewModel() // inicializa las propiedades.
            {
               // Numero1 = 200;
               // Numero2 = 400;
               // Resultado = 600;
            }



            /*
             new DelegateCommand(...): Estamos creando una nueva instancia de la clase DelegateCommand.
            Esta clase implementa la interfaz ICommand y se utiliza para definir 
            comandos en aplicaciones de WPF y otras tecnologías de interfaz de usuario en .NET.
             */
        }
    }
