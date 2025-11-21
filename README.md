# Spatial Audio System – VR Demo

Este proyecto demuestra un sistema de audio espacial en realidad virtual, permitiendo comparar audio 2D tradicional con audio 3D espacializado en distintos entornos. La aplicación ilustra cómo la percepción sonora cambia según la geometría y tamaño del espacio, haciendo evidente el impacto de la reverberación y la atenuación espacial.

## Tecnologías utilizadas
- Unity 2022.3 LTS  
- Resonance Audio SDK  
- Oculus Integration  
- XR Plugin Management (Oculus)  
- C#  

## Pre-requisitos
Para ejecutar o modificar el proyecto se requiere:
- Unity 2022.3.x LTS  
- Meta Quest en modo desarrollador  
- SideQuest, Meta Quest Developer Hub o ADB para instalar el ejecutable  
- Oculus Integration (solo si se van a extender o modificar las escenas)

## Imagen representativa
<img width="1037" height="417" alt="image" src="https://github.com/user-attachments/assets/08bb3505-c149-4505-9763-edf675f9b524" />


## Descripción general
La aplicación permite alternar entre dos modos de sonido:

1. **Audio 2D:** sonido plano sin espacialización ni interacción con el entorno.  
2. **Audio 3D espacial:** incluye reverberación, respuesta acústica basada en geometría y atenuación por distancia.

El usuario puede comparar ambos modos en tiempo real para comprender cómo la espacialización mejora la inmersión auditiva en VR.

## Características principales
- Conmutación inmediata entre audio 2D y audio 3D.  
- Escena con materiales y geometría que afectan la reverberación.  
- Integración con Resonance Audio.  
- Compatible con Meta Quest.  
- Control simple para alternar modo auditivo.  
- Escena principal ubicada en:  
  `Assets/ResonanceAudio/Demos/Scenes/ReverbBakingDemo.unity`

## Instrucciones de descarga del código (desarrollo)

git clone https://github.com/TU_USUARIO/SpatialAudioSystem.git
Luego abrir la carpeta en Unity 2022.3.x y cargar la escena indicada.

## Instrucciones de uso del ejecutable

El archivo .apk se encuentra en Releases del repositorio.

Instalar en Meta Quest mediante SideQuest, Meta Quest Developer Hub o ADB.

Al iniciar la aplicación, moverse usando los controles estándar del headset.

Alternar entre audio 2D y 3D presionando B (o el botón asignado en VR).
