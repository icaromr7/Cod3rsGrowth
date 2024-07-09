sap.ui.define([
"sap/ui/core/mvc/Controller",
"sap/ui/model/resource/ResourceModel"
], (Controller, ResourceModel) => {
"use strict";

return Controller.extend("ui5.anime.app.App", {
    onInit(){
        const i18nModel = new ResourceModel({
            bundleName: "ui5.anime.i18n.i18n"
        });
        this.getView().setModel(i18nModel, "i18n");
    },

    async onBemVindo() {
        this.oDialogo ??= await this.loadFragment({
            name: "ui5.anime.app.BemVindoDialogo"
        });

        this.oDialogo.open();
    },

    onFecharDialogo(){
        this.byId("bemVindoDialogo").close();
    }
});
});