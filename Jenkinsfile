pipeline {
	agent any
	stages {
		stage('Test'){
			sh 'dotnet test --test-adapter-path:. --logger:xunit'
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