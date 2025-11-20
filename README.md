# Spatial Audio System – VR Demo

Este proyecto demuestra un sistema de audio espacial en VR, permitiendo comparar sonido 2D tradicional con audio 3D espacializado dentro de distintos entornos. El objetivo es mostrar cómo la percepción del sonido cambia según la geometría y tamaño del espacio.

## Ejecución

### Instalación desde APK
El archivo `.apk` se encuentra disponible en la sección **Releases** del repositorio.  
Instalar en Meta Quest mediante SideQuest, Meta Quest Developer Hub o ADB.

### Ejecución desde Unity
1. Abrir el proyecto en Unity 2022.3 LTS.  
2. Cargar la escena principal ubicada en:  
   `Assets/Scenes/ReverbBakingDemo.unity`  
3. Ejecutar en modo VR o realizar Build & Run hacia el headset.

## Controles
- Movimiento y rotación: controles estándar del headset.  
- Cambio entre audio 2D y audio 3D espacial: tecla **B** o botón asignado en VR.

## Funcionalidad principal
El sistema permite alternar entre dos modos:
1. **Audio 2D:** sonido plano sin interacción con el entorno.  
2. **Audio 3D espacial:** incluye reverberación y respuesta acústica del entorno virtual.

Esto facilita la comparación inmediata entre ambos sistemas y su impacto perceptual.

## Notas
- El APK oficial se encuentra en **Releases**.  
- El proyecto requiere XR Plugin Management configurado con Oculus.
