pipeline {
  agent any

  stages {
    stage('Checkout') {
      steps {
        git credentialsId: 'alhajgit', url: 'https://github.com/alhaj1986/DotNetCorePipeline.git'
      }
    }

    stage('Build') {
      steps {
        sh 'dotnet build DotNetCorePipeline.sln'
      }
    }

    stage('Test') {
      steps {
        sh 'dotnet test DotNetCorePipeline.sln --logger "trx;LogFileName=TestResult.trx"'
      }
    }

    stage('Docker Build') {
      steps {
        script {
          docker.build('dotnetcorepipeline:latest')
        }
      }
    }
  }

  post {
    success {
      cleanWs()
    }
  }
}
