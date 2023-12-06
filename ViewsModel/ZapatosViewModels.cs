using ZapateriaTBD.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZapateriaTBD.DTOS;
using System.Windows.Input;
using GalaSoft.MvvmLight.Command;

namespace ZapateriaTBD.ViewsModel
{
    public class ZapatosViewModels : INotifyPropertyChanged

    {

        public ICommand VerRegistrarCommand { get; set; }
        public ICommand RegistrarCommand { get; set; }
        public ICommand RegresarCommand { get; set; }
        public ICommand VerEliminarCommand { get; set; }
        public ICommand VerEditarCommand { get; set; }
        public string Error { get; set; }
        ZapatosDTO contexto = new();
        public Zapatos Zapatox { get; set; }

        public string Vista {  get; set; }
        public event PropertyChangedEventHandler? PropertyChanged;
        public ObservableCollection<Zapatos> ListaZapatos { get; set; } = new ObservableCollection<Zapatos>();
        ZapatosDTO zDTO= new ZapatosDTO();

        public ZapatosViewModels()
        {
            ActualizarBD();
            ActualizarVistas();
            VerRegistrarCommand = new RelayCommand(VerRegistrar);
            RegistrarCommand = new RelayCommand(Registrar);
            RegresarCommand = new RelayCommand(Regresar);
            VerEliminarCommand = new RelayCommand(VerEliminar);
            VerEditarCommand = new RelayCommand(VerEditar);
            VerEliminarCommand = new RelayCommand(Eliminar);
        }
        private void Eliminar()
        {
            if (Zapatox != null)
            {
                contexto.Eliminar(Zapatox);
                Vista = "VerFrutas";
                ActualizarVistas();
                ActualizarBD();
            }

        }

        private void VerEliminar()
        {
            {
                Vista = "Eliminar";
                ActualizarVistas();
            }
        }

        private void Regresar()
        {
            Vista = "VerFrutas";
            ActualizarVistas();
            Zapatox = null;
        }

        private void Registrar()
        {
            if (Zapatox != null)
            {
                Error = "";
                if (contexto.Validar(Zapatox, out List<string> Errores))
                {
                    contexto.Agregar(Zapatox);
                    Vista = "VerFrutas";
                    ActualizarBD();
                    //ActualizarVistas();
                }
                else
                {
                    foreach (var item in Errores)
                    {
                        Error = $"{Error} {item} {Environment.NewLine}";
                    }
                }
                ActualizarVistas();
            }


        }

        private void VerRegistrar()
        {
            Vista = "Agregar";
            Zapatox = new Zapatos();
            ActualizarVistas();
        }

        private void ActualizarVistas()
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(null));
        }

        private void ActualizarBD()
        {
            ListaZapatos.Clear();
            //*Cargue toda la informacion de la base de datos utilizando DTO
            foreach (var z in zDTO.GetAll())
            {
                ListaZapatos.Add(z);
            }
        }
        private void VerEditar()
        {
            if (Zapatox != null)
            {
                Zapatos zt = new()
                {
                    Id = Zapatox.Id,
                    Marca = Zapatox.Marca,
                    Precio = Zapatox.Precio,
                    Descripcion = Zapatox.Descripcion,
                    Talla = Zapatox.Talla,
                    Color = Zapatox.Color
                    
                };
                Vista = "Editar";
                ActualizarVistas();
            }
        }

    }
}
