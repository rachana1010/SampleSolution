pipeline {
    agent any

    tools {
        dotnetsdk 'dotnet-sdk'  // Use the name you gave the .NET SDK in Global Tool Configuration
    }

    stages {
        stage('Checkout') {
            steps {
                checkout scm
            }
        }
        stage('Check NuGet Sources') {
            steps {
                script {
                    bat 'dotnet nuget list source'
                }
            }
        }
        stage('Configure NuGet Source') {
            steps {
                script {
                    def output = bat(script: 'dotnet nuget list source', returnStdout: true).trim()
                    if (!output.contains('https://api.nuget.org/v3/index.json')) {
                        bat 'dotnet nuget add source https://api.nuget.org/v3/index.json -n nuget.org'
                    } else {
                        echo 'NuGet source already exists.'
                    }
                }
            }
        }
        stage('Restore') {
            steps {
                script {
                    bat 'dotnet restore MyApp/MyApp.csproj'
                }
            }
        }
        stage('Build') {
            steps {
                script {
                    bat 'dotnet build MyApp/MyApp.csproj'
                }
            }
        }
        stage('Test') {
            steps {
                script {
                    bat 'dotnet test MyApp.Tests/MyApp.Tests.csproj --logger "trx;LogFileName=TestResults/test_results.trx"'
                }
            }
        }
        stage('List Test Results') {
            steps {
                script {
                    bat 'dir "MyApp.Tests\\TestResults"'
                }
            }
        }
        stage('Deploy') {
            steps {
                echo 'Deploying application...'
                // Deployment steps go here
            }
        }
    }

    
}
