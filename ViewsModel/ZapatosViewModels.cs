﻿using ZapateriaTBD.Models;
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
        public List<Categorias> ListaCategorias {  get; set; }
        public ICommand VerRegistrarCommand { get; set; }
        public ICommand RegistrarCommand { get; set; }
        public ICommand RegresarCommand { get; set; }
        public ICommand VerEliminarCommand { get; set; }
        public ICommand VerEditarCommand { get; set; }
        public string Error { get; set; }
        ZapatosDTO contexto = new();
        public Zapatos Zapatox { get; set; }
        ZapatosDTO zDTO= new ZapatosDTO();
        public string Vista {  get; set; }
        public event PropertyChangedEventHandler? PropertyChanged;
        public ObservableCollection<Zapatos> ListaZapatos { get; set; } = new ObservableCollection<Zapatos>();
       CategoriaDTO appDtos = new CategoriaDTO();

        public ZapatosViewModels()
        {
            var datos = zDTO.GetAll();
            foreach (var dato in datos)
            {
                ListaZapatos.Add(dato);
            }
            ActualizarBD();
            ListaCategorias = new List<Categorias>(appDtos.GetAll());
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
                Vista = "VerZapatos";
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
            Vista = "VerZapatos";
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
                    Vista = "VerZapatos";
                    ActualizarBD();
               
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
                    Color = Zapatox.Color,
                    IdCategorias = Zapatox.IdCategorias,
                    
                };
                Vista = "Editar";
                ActualizarVistas();
            }
        }

    }
}
