using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using App01_ConsultarCEP.Servico.Modelo;
using App01_ConsultarCEP.Servico;

namespace App01_ConsultarCEP
{
	public partial class MainPage : ContentPage
	{
		public MainPage()
		{
			InitializeComponent();

            BOTAO.Clicked += BuscarCEP;
           
		}

        private void BuscarCEP(object sender, EventArgs args)
        {
            //todo - logica do programa

            // todo - validações

            RESULTADO.Text = "";

            string cep = CEP.Text.Trim();

            if(isValidCEP(cep)) {

                try{
                    Endereco end = ViaCEPServico.BuscarEnderecoViaCEP(cep);

                    if (end != null)
                    {
                        RESULTADO.Text = string.Format("Endereço: {0},{1} {2}", end.localidade, end.uf, end.logradouro);
                    }
                    else
                    {
                        DisplayAlert("ERRO", "O endereço não foi localizado para o cep digitado: "+ cep, "OK");
                    }


                    
                }catch(Exception e){
                    DisplayAlert("Erro Critico",e.Message,"OK");
                }



                
            }
           
        }

        private bool isValidCEP(string cep)
        {

            bool valido = true;

           if(cep.Length !=8)
            {
                //erro
                DisplayAlert("ERRO", "CEP INVALIDO! O CEP deve contar 8 caracteres", "OK");
                valido = false;
            }

            int NovoCEP = 0;
            if(!int.TryParse(cep, out NovoCEP) )
            {
                //erro
                DisplayAlert("ERRO", "CEP INVALIDO! O CEP deve ser composto apenas por numeros", "OK");
                valido = false;
            }

            return valido;
        }


	}
}
