pipeline {
    agent any

    environment {
        // Definir variables de entorno necesarias
        INNO_SETUP_PATH = "C:\\Program Files (x86)\\Inno Setup 6"
        SCRIPT_FILE = "C:\\Users\\carma_ym7chdf\\Documents\\INNO output\\InstallerScript.iss"
        SOLUTION_PATH = "C:\\Users\\carma_ym7chdf\\source\\repos\\WinformsDemo\\WinformsDemo.sln"
        TEST_DLL_PATH = "C:\\Users\\carma_ym7chdf\\source\\repos\\WinformsDemo.Tests\\bin\\Release\\WinformsDemo.Tests.dll"
        VSTEST_PATH = "C:\\Program Files\\Microsoft Visual Studio\\2022\\Professional\\Common7\\IDE\\Extensions\\TestPlatform"
    }

    stages {
        stage('Restore NuGet Packages') {
            steps {
                script {
                    // Restaurar paquetes NuGet usando MSBuild
                    bat "\"C:\\Program Files\\Microsoft Visual Studio\\2022\\Professional\\MSBuild\\Current\\Bin\\msbuild.exe\" /t:Restore /p:Configuration=Release \"${env.SOLUTION_PATH}\""
                }
            }
        }

        stage('Build Solution') {
            steps {
                script {
                    // Compilar la solución
                    bat "\"C:\\Program Files\\Microsoft Visual Studio\\2022\\Professional\\MSBuild\\Current\\Bin\\msbuild.exe\" /p:Configuration=Release \"${env.SOLUTION_PATH}\""
                }
            }
        }

        stage('Build Tests') {
            steps {
                script {
                    bat "\"C:\\Program Files\\Microsoft Visual Studio\\2022\\Professional\\MSBuild\\Current\\Bin\\msbuild.exe\" /p:Configuration=Release \"${SOLUTION_PATH}\""
                }
            }
        }


        stage('Run Unit Tests') {
            steps {
                script {
                    bat "\"${VSTEST_PATH}\\vstest.console.exe\" \"${TEST_DLL_PATH}\""
                }
            }
        }

        stage('Static Code Analysis') {
            steps {
                script {
                    // Ejecutar análisis estático de código
                    // Agrega aquí el comando para análisis estático si tienes una herramienta configurada
                    echo 'Static code analysis step (optional) - add tool configuration here'
                }
            }
        }

        stage('Create Installer') {
            steps {
                script {
                    // Crear el instalador usando Inno Setup
                    bat "\"${env.INNO_SETUP_PATH}\\ISCC.exe\" \"${env.SCRIPT_FILE}\""
                }
            }
        }

        stage('Archive Artifacts') {
            steps {
                script {
                    // Archivar los artefactos generados
                    archiveArtifacts artifacts: '**/bin/Release/*.exe', allowEmptyArchive: true
                }
            }
        }

        stage('Notify') {
            steps {
                script {
                    // Enviar notificaciones (opcional)
                    echo 'Sending notifications - configure as needed'
                }
            }
        }
    }

    post {
        always {
            // Limpiar cualquier recurso o realizar acciones después de la construcción
            echo 'Cleaning up after build'
        }
    }
}
