pipeline {
	agent any
	stages {
		stage('Unit Tests') {
			step('Run Unit Tests') {
				bat 'dotnet test --test-adapter-path:. --logger:xunit'
			}
		}
	}
}
post {
	always {
		xunit (
			thresholds: [ skipped(failureThreshold: '0'), failed(failureThreshold: '0') ],
			tools: [ BoostTest(pattern: 'boost/*.xml') ]
		)
	}
}