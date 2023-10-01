resource "azurerm_resource_group" "main-resource-group" {
  name     = var.resource_group_name
  location = "westeurope"
}

resource "azurerm_service_plan" "mam-service-plan" {
  name                = "mam-service-plan"
  location            = azurerm_resource_group.main-resource-group.location
  resource_group_name = azurerm_resource_group.main-resource-group.name
  os_type             = "Linux"
  sku_name            = "B1"
}

resource "azurerm_linux_web_app" "mam-api" {
  name                = "mam-api"
  location            = azurerm_resource_group.main-resource-group.location
  resource_group_name = azurerm_resource_group.main-resource-group.name
  service_plan_id     = azurerm_service_plan.mam-service-plan.id
  https_only          = true
  
  app_settings = {
    "ASPNETCORE_ENVIRONMENT" = "Production"
    "WEBSITES_PORT" = "8000"
    "WEBSITES_ENABLE_APP_SERVICE_STORAGE" = "false"
  }  

  site_config {
    always_on = true
    http2_enabled = true

    application_stack {
      docker_image_name = "danielagg/mam-api:latest"
    }

    cors {
      allowed_origins = ["http://localhost:5173/", "https://mam.danielagg.com/"]
    }
  }
}