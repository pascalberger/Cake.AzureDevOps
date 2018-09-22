﻿namespace Cake.Tfs.Tests.PullRequest
{
    using System;
    using Cake.Tfs.Authentication;
    using Cake.Tfs.PullRequest;
    using Shouldly;
    using Xunit;

    public sealed class TfsPullRequestSettingsTests
    {
        public sealed class TheCtorForSourceBranch
        {
            [Fact]
            public void Should_Throw_If_RepositoryUrl_Is_Null()
            {
                // Given
                Uri repositoryUrl = null;
                var sourceBranch = "foo";
                ITfsCredentials credentials = AuthenticationProvider.AuthenticationNtlm();

                // When
                var result = Record.Exception(() => new TfsPullRequestSettings(repositoryUrl, sourceBranch, credentials));

                // Then
                result.IsArgumentNullException("repositoryUrl");
            }

            [Fact]
            public void Should_Throw_If_SourceBranch_Is_Null()
            {
                // Given
                var repositoryUrl = new Uri("http://example.com");
                string sourceBranch = null;
                ITfsCredentials credentials = AuthenticationProvider.AuthenticationNtlm();

                // When
                var result = Record.Exception(() => new TfsPullRequestSettings(repositoryUrl, sourceBranch, credentials));

                // Then
                result.IsArgumentNullException("sourceBranch");
            }

            [Fact]
            public void Should_Throw_If_SourceBranch_Is_Empty()
            {
                // Given
                var repositoryUrl = new Uri("http://example.com");
                var sourceBranch = string.Empty;
                ITfsCredentials credentials = AuthenticationProvider.AuthenticationNtlm();

                // When
                var result = Record.Exception(() => new TfsPullRequestSettings(repositoryUrl, sourceBranch, credentials));

                // Then
                result.IsArgumentOutOfRangeException("sourceBranch");
            }

            [Fact]
            public void Should_Throw_If_SourceBranch_Is_WhiteSpace()
            {
                // Given
                var repositoryUrl = new Uri("http://example.com");
                var sourceBranch = " ";
                ITfsCredentials credentials = AuthenticationProvider.AuthenticationNtlm();

                // When
                var result = Record.Exception(() => new TfsPullRequestSettings(repositoryUrl, sourceBranch, credentials));

                // Then
                result.IsArgumentOutOfRangeException("sourceBranch");
            }

            [Fact]
            public void Should_Throw_If_Credentials_Are_Null()
            {
                // Given
                var repositoryUrl = new Uri("http://example.com");
                var sourceBranch = "foo";
                ITfsCredentials credentials = null;

                // When
                var result = Record.Exception(() => new TfsPullRequestSettings(repositoryUrl, sourceBranch, credentials));

                // Then
                result.IsArgumentNullException("credentials");
            }

            [Fact]
            public void Should_Set_Repository_Url()
            {
                // Given
                var repositoryUrl = new Uri("http://example.com");
                var sourceBranch = "foo";
                ITfsCredentials credentials = AuthenticationProvider.AuthenticationNtlm();

                // When
                var result = new TfsPullRequestSettings(repositoryUrl, sourceBranch, credentials);

                // Then
                result.RepositoryUrl.ShouldBe(repositoryUrl);
            }

            [Fact]
            public void Should_Set_SourceBranch()
            {
                // Given
                var repositoryUrl = new Uri("http://example.com");
                var sourceBranch = "foo";
                ITfsCredentials credentials = AuthenticationProvider.AuthenticationNtlm();

                // When
                var result = new TfsPullRequestSettings(repositoryUrl, sourceBranch, credentials);

                // Then
                result.SourceBranch.ShouldBe(sourceBranch);
            }

            [Fact]
            public void Should_Set_Credentials()
            {
                // Given
                var repositoryUrl = new Uri("http://example.com");
                var sourceBranch = "foo";
                ITfsCredentials credentials = AuthenticationProvider.AuthenticationNtlm();

                // When
                var result = new TfsPullRequestSettings(repositoryUrl, sourceBranch, credentials);

                // Then
                result.Credentials.ShouldBe(credentials);
            }
        }

        public sealed class TheCtorForPullRequestId
        {
            [Fact]
            public void Should_Throw_If_RepositoryUrl_Is_Null()
            {
                // Given
                Uri repositoryUrl = null;
                var pullRequestId = 41;
                ITfsCredentials credentials = AuthenticationProvider.AuthenticationNtlm();

                // When
                var result = Record.Exception(() => new TfsPullRequestSettings(repositoryUrl, pullRequestId, credentials));

                // Then
                result.IsArgumentNullException("repositoryUrl");
            }

            [Fact]
            public void Should_Throw_If_PullRequestId_Is_Zero()
            {
                // Given
                var repositoryUrl = new Uri("http://example.com");
                var pullRequestId = 0;
                ITfsCredentials credentials = AuthenticationProvider.AuthenticationNtlm();

                // When
                var result = Record.Exception(() => new TfsPullRequestSettings(repositoryUrl, pullRequestId, credentials));

                // Then
                result.IsArgumentOutOfRangeException("pullRequestId");
            }

            [Theory]
            [InlineData(-1)]
            [InlineData(int.MinValue)]
            public void Should_Throw_If_PullRequestId_Is_Negative(int pullRequestId)
            {
                // Given
                var repositoryUrl = new Uri("http://example.com");
                ITfsCredentials credentials = AuthenticationProvider.AuthenticationNtlm();

                // When
                var result = Record.Exception(() => new TfsPullRequestSettings(repositoryUrl, pullRequestId, credentials));

                // Then
                result.IsArgumentOutOfRangeException("pullRequestId");
            }

            [Fact]
            public void Should_Throw_If_Credentials_Are_Null()
            {
                // Given
                var repositoryUrl = new Uri("http://example.com");
                var pullRequestId = 41;
                ITfsCredentials credentials = null;

                // When
                var result = Record.Exception(() => new TfsPullRequestSettings(repositoryUrl, pullRequestId, credentials));

                // Then
                result.IsArgumentNullException("credentials");
            }

            [Fact]
            public void Should_Set_Repository_Url()
            {
                // Given
                var repositoryUrl = new Uri("http://example.com");
                var pullRequestId = 41;
                ITfsCredentials credentials = AuthenticationProvider.AuthenticationNtlm();

                // When
                var result = new TfsPullRequestSettings(repositoryUrl, pullRequestId, credentials);

                // Then
                result.RepositoryUrl.ShouldBe(repositoryUrl);
            }

            [Theory]
            [InlineData(1)]
            [InlineData(int.MaxValue)]
            public void Should_Set_PullRequestId(int pullRequestId)
            {
                // Given
                var repositoryUrl = new Uri("http://example.com");
                ITfsCredentials credentials = AuthenticationProvider.AuthenticationNtlm();

                // When
                var result = new TfsPullRequestSettings(repositoryUrl, pullRequestId, credentials);

                // Then
                result.PullRequestId.ShouldBe(pullRequestId);
            }

            [Fact]
            public void Should_Set_Credentials()
            {
                // Given
                var repositoryUrl = new Uri("http://example.com");
                var pullRequestId = 41;
                ITfsCredentials credentials = AuthenticationProvider.AuthenticationNtlm();

                // When
                var result = new TfsPullRequestSettings(repositoryUrl, pullRequestId, credentials);

                // Then
                result.Credentials.ShouldBe(credentials);
            }
        }

        public sealed class TheCtorForSettings
        {
            [Fact]
            public void Should_Throw_If_Settings_Are_Null()
            {
                // Given
                TfsPullRequestSettings settings = null;

                // When
                var result = Record.Exception(() => new TfsPullRequestSettings(settings));

                // Then
                result.IsArgumentNullException("settings");
            }

            [Fact]
            public void Should_Set_Repository_Url()
            {
                // Given
                var repositoryUrl = new Uri("http://example.com");
                var pullRequestId = 41;
                ITfsCredentials credentials = AuthenticationProvider.AuthenticationNtlm();
                var settings = new TfsPullRequestSettings(repositoryUrl, pullRequestId, credentials);

                // When
                var result = new TfsPullRequestSettings(settings);

                // Then
                result.RepositoryUrl.ShouldBe(repositoryUrl);
            }

            [Theory]
            [InlineData(1)]
            [InlineData(int.MaxValue)]
            public void Should_Set_PullRequestId(int pullRequestId)
            {
                // Given
                var repositoryUrl = new Uri("http://example.com");
                ITfsCredentials credentials = AuthenticationProvider.AuthenticationNtlm();
                var settings = new TfsPullRequestSettings(repositoryUrl, pullRequestId, credentials);

                // When
                var result = new TfsPullRequestSettings(settings);

                // Then
                result.PullRequestId.ShouldBe(pullRequestId);
            }

            [Fact]
            public void Should_Set_SourceBranch()
            {
                // Given
                var repositoryUrl = new Uri("http://example.com");
                var sourceBranch = "foo";
                ITfsCredentials credentials = AuthenticationProvider.AuthenticationNtlm();
                var settings = new TfsPullRequestSettings(repositoryUrl, sourceBranch, credentials);

                // When
                var result = new TfsPullRequestSettings(settings);

                // Then
                result.SourceBranch.ShouldBe(sourceBranch);
            }

            [Fact]
            public void Should_Set_Credentials()
            {
                // Given
                var repositoryUrl = new Uri("http://example.com");
                var pullRequestId = 41;
                ITfsCredentials credentials = AuthenticationProvider.AuthenticationNtlm();
                var settings = new TfsPullRequestSettings(repositoryUrl, pullRequestId, credentials);

                // When
                var result = new TfsPullRequestSettings(settings);

                // Then
                result.Credentials.ShouldBe(credentials);
            }

            [Theory]
            [InlineData(true)]
            [InlineData(false)]
            public void Should_Set_ThrowExceptionIfPullRequestCouldNotBeFound(bool value)
            {
                // Given
                var repositoryUrl = new Uri("http://example.com");
                var pullRequestId = 41;
                ITfsCredentials credentials = AuthenticationProvider.AuthenticationNtlm();
                var settings = new TfsPullRequestSettings(repositoryUrl, pullRequestId, credentials);
                settings.ThrowExceptionIfPullRequestCouldNotBeFound = value;

                // When
                var result = new TfsPullRequestSettings(settings);

                // Then
                result.ThrowExceptionIfPullRequestCouldNotBeFound.ShouldBe(value);
            }
        }
    }
}