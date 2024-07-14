pipeline {
    agent any

    environment {
        SOLUTION_PATH = "F:\\Documentos\\Projetos\\Development\\Github\\MyCar\\MyCar.API.sln"
        TEST_PROJECT_PATH = "F:\\Documentos\\Projetos\\Development\\Github\\MyCarUnitTests\\MyCarUnitTests.csproj"
        WORKSPACE_PATH = "${WORKSPACE}"
        MANIFEST_PATH = "F:\\Documentos\\Projetos\\Development\\Github\\MyCar\\Package.appxmanifest"
        CERTIFICATE_PATH = "<path-to-certificate-file>.pfx"
    }

    stages {
        stage('Clean workspace') {
            steps {
                cleanWs()
            }
        }
		
        stage('Git Checkout') {
            steps {
                git branch: 'JenkinsBranch', credentialsId: 'c208a5d1-8c92-4c56-9e77-7a6d49f1cfa7', url: 'https://github.com/SouzaFS/MyCar.git'
            }
        }
		
        stage('Restore packages') {
            steps {
                bat "dotnet restore ${env.SOLUTION_PATH}"
            }
        }
		
        stage('Clean') {
            steps {
                bat "msbuild.exe ${env.SOLUTION_PATH} /nologo /nr:false /p:platform=\"x64\" /p:configuration=\"release\" /t:clean"
            }
        }
		
        stage('Increase version') {
            steps {
                echo "${env.BUILD_NUMBER}"
                powershell '''
                    $xmlFileName = "${env:MANIFEST_PATH}"
                    [xml]$xmlDoc = Get-Content $xmlFileName
                    $version = $xmlDoc.Package.Identity.Version
                    $trimmedVersion = $version -replace '.[0-9]+$', '.'
                    $xmlDoc.Package.Identity.Version = $trimmedVersion + ${env:BUILD_NUMBER}
                    echo 'New version:' $xmlDoc.Package.Identity.Version
                    $xmlDoc.Save($xmlFileName)
                '''
            }
        }
		
        stage('Build') {
            steps {
                bat "msbuild.exe ${env.SOLUTION_PATH} /nologo /nr:false /p:platform=\"x64\" /p:configuration=\"release\" /p:PackageCertificateKeyFile=${env.CERTIFICATE_PATH} /t:clean;restore;rebuild"
            }
        }
		
        stage('Running unit tests') {
            steps {
                bat "dotnet add ${env.TEST_PROJECT_PATH} package JUnitTestLogger --version 1.1.0"
                bat "dotnet test ${env.TEST_PROJECT_PATH} --logger \"junit;LogFilePath=${env.WORKSPACE_PATH}/TestResults/1.0.0.${env.BUILD_NUMBER}/results.xml\" --configuration release --collect \"Code coverage\""
                powershell '''
                    $destinationFolder = "${env:WORKSPACE}/TestResults"
                    if (!(Test-Path -path $destinationFolder)) {New-Item $destinationFolder -Type Directory}
                    $file = Get-ChildItem -Path "${env:WORKSPACE}/<path-to-Unit-testing-project>/<name-of-unit-test-project>/TestResults/*/*.coverage"
                    $file | Rename-Item -NewName testcoverage.coverage
                    $renamedFile = Get-ChildItem -Path "${env:WORKSPACE}/<path-to-Unit-testing-project>/<name-of-unit-test-project>/TestResults/*/*.coverage"
                    Copy-Item $renamedFile -Destination $destinationFolder
                '''            
            }        
        }
    }
}
