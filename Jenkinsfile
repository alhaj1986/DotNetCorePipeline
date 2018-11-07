pipeline {
  agent any
  environment {
    dotnet = 'C:/Program Files/dotnet/dotnet.exe'
  }
  stages {
    stage('Checkout') {
      steps {
        git url: 'https://github.com/manjunath-papanna/DotNetCorePipeline.git', branch: 'master'
      }
    }
    stage('Restore') {
      steps {
        bat "dotnet restore"
      }
    }
    stage('Clean') {
      steps {
        bat 'dotnet clean'
      }
    }
    stage('Build') {
      steps {
        bat 'dotnet build'
      }
    }
    stage('Test') {
      steps {
	      bat returnStatus: true, script: 'dotnet test ./ConsoleAppTest/ConsoleAppTest.csproj --logger trx;LogFileName=TestResult.xml --no-build'
	      step([$class: 'MSTestPublisher', testResultsFile:'**/TestResult.xml', failOnError: true, keepLongStdio: true])
	    }     
    }
    stage('Publish') {
      steps {
        bat 'dotnet publish ./ConsoleApp/ConsoleApp.csproj -c Release -o ./dist/'
      }
    }
  }
}