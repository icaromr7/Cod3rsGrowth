sap.ui.define([
	"sap/ui/core/mvc/Controller",
    "sap/ui/core/routing/History",
	"sap/ui/core/UIComponent",
    "sap/m/MessageBox",
    "sap/ui/model/json/JSONModel"
], function(Controller, History, UIComponent, MessageBox, JSONModel) {
    "use strict";

    const MESSAGEM_DE_ERRO = "Ocorreu um erro: ";
    const ROTA_PARA_LISTA = "lista";

    return Controller.extend("ui5.codersgrowth.app.common.ControleBase", {

        _exibirEspera: function(funcao){
            let aPagina = this.getView();
            aPagina.setBusy(true);
            try{
                funcao();
            }catch(error){
                MessageBox.error(MESSAGEM_DE_ERRO + error.message);
            }
            finally{
                aPagina.setBusy(false);
            }
        },

        _getRota : function () {
            return UIComponent.getRouterFor(this);
        },

        aoClicarEmVoltar: function () {
            var oHistory, sPreviousHash;
    
            oHistory = History.getInstance();
            sPreviousHash = oHistory.getPreviousHash();
    
            if (sPreviousHash !== undefined) {
                window.history.go(-1);
            } else {
                this._getRota().navTo(ROTA_PARA_LISTA, {}, true);
            }
        },
        _modeloLista: function(oModel, oNomeModelo){
			this.getView().setModel(oModel,oNomeModelo);
		},
        _get: async function(url, oNomeModelo){
			this._exibirEspera(async () => {
				const response = await fetch (url,{
					method: "GET",
					headers: {
						"Content-Type": "application/json"
					}
				});
				if(response.ok){
					const data = await response.json();
					const oModel = new JSONModel(data);
					return this._modeloLista(oModel, oNomeModelo);
				}
			});

		}

    });
    
}
);