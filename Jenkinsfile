pipeline {
  agent any
  environment {
    dotnet = 'C:/Program Files/dotnet/dotnet.exe'
  }
  stages {
    stage('Checkout') {
      steps {
        git url: 'https://github.com/manjunath-papanna/DotNetCorePipeline.git', branch: 'master'
        bat 'dotnet restore DotNetCorePipeline.sln'
        bat 'dotnet clean DotNetCorePipeline.sln'
      }
    }
    stage('Build') {
      steps {
        bat 'dotnet build DotNetCorePipeline.sln'
      }
    }
    stage('Test') {
      steps {
	      bat 'dotnet test /p:CollectCoverage=true /p:CoverletOutputFormat=opencover ./ConsoleAppTest/ConsoleAppTest.csproj --logger "trx;LogFileName=TestResult.trx"'
        bat 'reportgenerator "-reports:./ConsoleAppTest/coverage.opencover.xml" "-targetdir:CoverageReport"'
	    }     
    }
    stage('Publish') {
      steps {
        bat 'dotnet publish ./ConsoleApp/ConsoleApp.csproj -c Release -o C:/JenkinsBuilds/${env.JOB_NAME}/${env.BUILD_NUMBER}'
      }
    }
  }
  post { 
    success {
      publishHTML (target: [allowMissing: false, alwaysLinkToLastBuild: false, keepAll: false, reportDir: './CoverageReport', reportFiles: 'index.htm', reportTitles: "CodeCoverageReport", reportName: "Code Coverage Report", includes: '**/*', escapeUnderscores: true])
      step([$class: 'MSTestPublisher', testResultsFile:'**/TestResult.trx', failOnError: true, keepLongStdio: true])
      cleanWs()
    }
  }
}