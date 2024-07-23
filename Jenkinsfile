pipeline {
    agent any
    stages {
        stage('Unit Tests') {
            steps {
                script {
                    bat 'dotnet test --test-adapter-path:. --logger:xunit'
                }
            }
        }
    }
    post {
        always {
            xunit (
                thresholds: [ skipped(failureThreshold: '0'), failed(failureThreshold: '0') ],
                tools: [ XUnit(pattern: '**/TestResults/*.xml') ]
            )
        }
    }
}
