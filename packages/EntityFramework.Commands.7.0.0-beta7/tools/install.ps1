﻿param ($installPath, $toolsPath, $package, $project)

Write-Host
Write-Host 'Type ''get-help EntityFramework'' to see all available Entity Framework commands.'
Write-Host

# SIG # Begin signature block
# MIIp/AYJKoZIhvcNAQcCoIIp7TCCKekCAQExDzANBglghkgBZQMEAgEFADB5Bgor
# BgEEAYI3AgEEoGswaTA0BgorBgEEAYI3AgEeMCYCAwEAAAQQH8w7YFlLCE63JNLG
# KX7zUQIBAAIBAAIBAAIBAAIBADAxMA0GCWCGSAFlAwQCAQUABCB4n3xzZbr0mm2T
# iS3SyAMVPYS0t9rVJKBKmLD+wzwTTqCCDZIwggYQMIID+KADAgECAhMzAAAAOI0j
# bRYnoybgAAAAAAA4MA0GCSqGSIb3DQEBCwUAMH4xCzAJBgNVBAYTAlVTMRMwEQYD
# VQQIEwpXYXNoaW5ndG9uMRAwDgYDVQQHEwdSZWRtb25kMR4wHAYDVQQKExVNaWNy
# b3NvZnQgQ29ycG9yYXRpb24xKDAmBgNVBAMTH01pY3Jvc29mdCBDb2RlIFNpZ25p
# bmcgUENBIDIwMTEwHhcNMTQxMDAxMTgxMTE2WhcNMTYwMTAxMTgxMTE2WjCBgzEL
# MAkGA1UEBhMCVVMxEzARBgNVBAgTCldhc2hpbmd0b24xEDAOBgNVBAcTB1JlZG1v
# bmQxHjAcBgNVBAoTFU1pY3Jvc29mdCBDb3Jwb3JhdGlvbjENMAsGA1UECxMETU9Q
# UjEeMBwGA1UEAxMVTWljcm9zb2Z0IENvcnBvcmF0aW9uMIIBIjANBgkqhkiG9w0B
# AQEFAAOCAQ8AMIIBCgKCAQEAwt7Wz+K3fxFl/7NjqfNyufEk61+kHLJEWetvnPtw
# 22VpmquQMV7/3itkEfXtbOkAIYLDkMyCGaPjmWNlir3T1fsgo+AZf7iNPGr+yBKN
# 5dM5701OPoaWTBGxEYSbJ5iIOy3UfRjzBeCtSwQ+Q3UZ5kbEjJ3bidgkh770Rye/
# bY3ceLnDZaFvN+q8caadrI6PjYiRfqg3JdmBJKmI9GNG6rsgyQEv2I4M2dnt4Db7
# ZGhN/EIvkSCpCJooSkeo8P7Zsnr92Og4AbyBRas66Boq3TmDPwfb2OGP/DksNp4B
# n+9od8h4bz74IP+WGhC+8arQYZ6omoS/Pq6vygpZ5Y2LBQIDAQABo4IBfzCCAXsw
# HwYDVR0lBBgwFgYIKwYBBQUHAwMGCisGAQQBgjdMCAEwHQYDVR0OBBYEFMbxyhgS
# CySlRfWC5HUl0C8w12JzMFEGA1UdEQRKMEikRjBEMQ0wCwYDVQQLEwRNT1BSMTMw
# MQYDVQQFEyozMTY0MitjMjJjOTkzNi1iM2M3LTQyNzEtYTRiZC1mZTAzZmE3MmMz
# ZjAwHwYDVR0jBBgwFoAUSG5k5VAF04KqFzc3IrVtqMp1ApUwVAYDVR0fBE0wSzBJ
# oEegRYZDaHR0cDovL3d3dy5taWNyb3NvZnQuY29tL3BraW9wcy9jcmwvTWljQ29k
# U2lnUENBMjAxMV8yMDExLTA3LTA4LmNybDBhBggrBgEFBQcBAQRVMFMwUQYIKwYB
# BQUHMAKGRWh0dHA6Ly93d3cubWljcm9zb2Z0LmNvbS9wa2lvcHMvY2VydHMvTWlj
# Q29kU2lnUENBMjAxMV8yMDExLTA3LTA4LmNydDAMBgNVHRMBAf8EAjAAMA0GCSqG
# SIb3DQEBCwUAA4ICAQCecm6ourY1Go2EsDqVN+I0zXvsz1Pk7qvGGDEWM3tPIv6T
# dVZHTXRrmYdcLnSIcKVGb7ScG5hZEk00vtDcdbNdDDPW2AX2NRt+iUjB5YmlLTo3
# J0ce7mjTaFpGoqyF+//Q6OjVYFXnRGtNz73epdy71XqL0+NIx0Z7dZhz+cPI7IgQ
# C/cqLRN4Eo/+a6iYXhxJzjqmNJZi2+7m4wzZG2PH+hhh7LkACKvkzHwSpbamvWVg
# Dh0zWTjfFuEyXH7QexIHgbR+uKld20T/ZkyeQCapTP5OiT+W0WzF2K7LJmbhv2Xj
# 97tj+qhtKSodJ8pOJ8q28Uzq5qdtCrCRLsOEfXKAsfg+DmDZzLsbgJBPixGIXncI
# u+OKq39vCT4rrGfBR+2yqF16PLAF9WCK1UbwVlzypyuwLhEWr+KR0t8orebVlT/4
# uPVr/wLnudvNvP2zQMBxrkadjG7k9gVd7O4AJ4PIRnvmwjrh7xy796E3RuWGq5eu
# dXp27p5LOwbKH6hcrI0VOSHmveHCd5mh9yTx2TgeTAv57v+RbbSKSheIKGPYUGNc
# 56r7VYvEQYM3A0ABcGOfuLD5aEdfonKLCVMOP7uNQqATOUvCQYMvMPhbJvgfuS1O
# eQy77Hpdnzdq2Uitdp0v6b5sNlga1ZL87N/zsV4yFKkTE/Upk/XJOBbXNedrODCC
# B3owggVioAMCAQICCmEOkNIAAAAAAAMwDQYJKoZIhvcNAQELBQAwgYgxCzAJBgNV
# BAYTAlVTMRMwEQYDVQQIEwpXYXNoaW5ndG9uMRAwDgYDVQQHEwdSZWRtb25kMR4w
# HAYDVQQKExVNaWNyb3NvZnQgQ29ycG9yYXRpb24xMjAwBgNVBAMTKU1pY3Jvc29m
# dCBSb290IENlcnRpZmljYXRlIEF1dGhvcml0eSAyMDExMB4XDTExMDcwODIwNTkw
# OVoXDTI2MDcwODIxMDkwOVowfjELMAkGA1UEBhMCVVMxEzARBgNVBAgTCldhc2hp
# bmd0b24xEDAOBgNVBAcTB1JlZG1vbmQxHjAcBgNVBAoTFU1pY3Jvc29mdCBDb3Jw
# b3JhdGlvbjEoMCYGA1UEAxMfTWljcm9zb2Z0IENvZGUgU2lnbmluZyBQQ0EgMjAx
# MTCCAiIwDQYJKoZIhvcNAQEBBQADggIPADCCAgoCggIBAKvw+nIQHC6t2G6qghBN
# NLrytlghn0IbKmvpWlCquAY4GgRJun/DDB7dN2vGEtgL8DjCmQawyDnVARQxQtOJ
# DXlkh36UYCRsr55JnOloXtLfm1OyCizDr9mpK656Ca/XllnKYBoF6WZ26DJSJhIv
# 56sIUM+zRLdd2MQuA3WraPPLbfM6XKEW9Ea64DhkrG5kNXimoGMPLdNAk/jj3gcN
# 1Vx5pUkp5w2+oBN3vpQ97/vjK1oQH01WKKJ6cuASOrdJXtjt7UORg9l7snuGG9k+
# sYxd6IlPhBryoS9Z5JA7La4zWMW3Pv4y07MDPbGyr5I4ftKdgCz1TlaRITUlwzlu
# ZH9TupwPrRkjhMv0ugOGjfdf8NBSv4yUh7zAIXQlXxgotswnKDglmDlKNs98sZKu
# HCOnqWbsYR9q4ShJnV+I4iVd0yFLPlLEtVc/JAPw0XpbL9Uj43BdD1FGd7P4AOG8
# rAKCX9vAFbO9G9RVS+c5oQ/pI0m8GLhEfEXkwcNyeuBy5yTfv0aZxe/CHFfbg43s
# TUkwp6uO3+xbn6/83bBm4sGXgXvt1u1L50kppxMopqd9Z4DmimJ4X7IvhNdXnFy/
# dygo8e1twyiPLI9AN0/B4YVEicQJTMXUpUMvdJX3bvh4IFgsE11glZo+TzOE2rCI
# F96eTvSWsLxGoGyY0uDWiIwLAgMBAAGjggHtMIIB6TAQBgkrBgEEAYI3FQEEAwIB
# ADAdBgNVHQ4EFgQUSG5k5VAF04KqFzc3IrVtqMp1ApUwGQYJKwYBBAGCNxQCBAwe
# CgBTAHUAYgBDAEEwCwYDVR0PBAQDAgGGMA8GA1UdEwEB/wQFMAMBAf8wHwYDVR0j
# BBgwFoAUci06AjGQQ7kUBU7h6qfHMdEjiTQwWgYDVR0fBFMwUTBPoE2gS4ZJaHR0
# cDovL2NybC5taWNyb3NvZnQuY29tL3BraS9jcmwvcHJvZHVjdHMvTWljUm9vQ2Vy
# QXV0MjAxMV8yMDExXzAzXzIyLmNybDBeBggrBgEFBQcBAQRSMFAwTgYIKwYBBQUH
# MAKGQmh0dHA6Ly93d3cubWljcm9zb2Z0LmNvbS9wa2kvY2VydHMvTWljUm9vQ2Vy
# QXV0MjAxMV8yMDExXzAzXzIyLmNydDCBnwYDVR0gBIGXMIGUMIGRBgkrBgEEAYI3
# LgMwgYMwPwYIKwYBBQUHAgEWM2h0dHA6Ly93d3cubWljcm9zb2Z0LmNvbS9wa2lv
# cHMvZG9jcy9wcmltYXJ5Y3BzLmh0bTBABggrBgEFBQcCAjA0HjIgHQBMAGUAZwBh
# AGwAXwBwAG8AbABpAGMAeQBfAHMAdABhAHQAZQBtAGUAbgB0AC4gHTANBgkqhkiG
# 9w0BAQsFAAOCAgEAZ/KGpZjgVHkaLtPYdGcimwuWEeFjkplCln3SeQyQwWVfLiw+
# +MNy0W2D/r4/6ArKO79HqaPzadtjvyI1pZddZYSQfYtGUFXYDJJ80hpLHPM8QotS
# 0LD9a+M+By4pm+Y9G6XUtR13lDni6WTJRD14eiPzE32mkHSDjfTLJgJGKsKKELuk
# qQUMm+1o+mgulaAqPyprWEljHwlpblqYluSD9MCP80Yr3vw70L01724lruWvJ+3Q
# 3fMOr5kol5hNDj0L8giJ1h/DMhji8MUtzluetEk5CsYKwsatruWy2dsViFFFWDgy
# cScaf7H0J/jeLDogaZiyWYlobm+nt3TDQAUGpgEqKD6CPxNNZgvAs0314Y9/HG8V
# fUWnduVAKmWjw11SYobDHWM2l4bf2vP48hahmifhzaWX0O5dY0HjWwechz4GdwbR
# BrF1HxS+YWG18NzGGwS+30HHDiju3mUv7Jf2oVyW2ADWoUa9WfOXpQlLSBCZgB/Q
# ACnFsZulP0V3HjXG0qKin3p6IvpIlR+r+0cjgPWe+L9rt0uX4ut1eBrs6jeZeRhL
# /9azI2h15q/6/IvrC4DqaTuv/DDtBEyO3991bWORPdGdVk5Pv4BXIqF4ETIheu9B
# CrE/+6jMpF3BoYibV3FWTkhFwELJm3ZbCoBIa/15n8G9bW1qyVJzEw16UM0xghvA
# MIIbvAIBATCBlTB+MQswCQYDVQQGEwJVUzETMBEGA1UECBMKV2FzaGluZ3RvbjEQ
# MA4GA1UEBxMHUmVkbW9uZDEeMBwGA1UEChMVTWljcm9zb2Z0IENvcnBvcmF0aW9u
# MSgwJgYDVQQDEx9NaWNyb3NvZnQgQ29kZSBTaWduaW5nIFBDQSAyMDExAhMzAAAA
# OI0jbRYnoybgAAAAAAA4MA0GCWCGSAFlAwQCAQUAoIG6MBkGCSqGSIb3DQEJAzEM
# BgorBgEEAYI3AgEEMBwGCisGAQQBgjcCAQsxDjAMBgorBgEEAYI3AgEVMC8GCSqG
# SIb3DQEJBDEiBCC29cgMmbcBkzFtsX4AfGL6zLwTFV8ECJXQMjs6WUcoOjBOBgor
# BgEEAYI3AgEMMUAwPqAkgCIATQBpAGMAcgBvAHMAbwBmAHQAIABBAFMAUAAuAE4A
# RQBUoRaAFGh0dHA6Ly93d3cuYXNwLm5ldC8gMA0GCSqGSIb3DQEBAQUABIIBADXF
# gZurcwlUEaDyhxeXAzwOFoON3gZKi1zKALxH47hPUxcr8EBCn+FezM/c7dQaZmx/
# F7gcPykAByYKL7yqjlNE3vTKFv1igdkwtmUq+39HXGKTYj5KW7ZsDcZdLvRgqFNE
# 6bWaKLS5IaGXvsNWMrQMA3j75r0b6c2FEt3R1CRmU71TdObT9lssgSZnN/tQ6Sfg
# FL0gU8a4YBIMRfdvdbNf069so/ApJ5ryvrwGDNma5m+3AJjbg1V5huAfIPUkMaru
# ohtzwwkgnpG+tO8cI7wIO6IhY4mioillxhOgdIOkI+gldMS97rbflFGzLPAoGk1s
# GbOL3Q07mKy4zuw5WyOhghk+MIIZOgYKKwYBBAGCNwMDATGCGSowghkmBgkqhkiG
# 9w0BBwKgghkXMIIZEwIBAzEPMA0GCWCGSAFlAwQCAQUAMIIBPQYLKoZIhvcNAQkQ
# AQSgggEsBIIBKDCCASQCAQEGCisGAQQBhFkKAwEwMTANBglghkgBZQMEAgEFAAQg
# VchA8FUoYLQslNTCo2tQsE82OKKfEVx1RYpBMg/tA/oCBlXUn0f4TxgTMjAxNTA4
# MjgwNTA5MDYuNTQzWjAHAgEBgAIB9KCBuaSBtjCBszELMAkGA1UEBhMCVVMxEzAR
# BgNVBAgTCldhc2hpbmd0b24xEDAOBgNVBAcTB1JlZG1vbmQxHjAcBgNVBAoTFU1p
# Y3Jvc29mdCBDb3Jwb3JhdGlvbjENMAsGA1UECxMETU9QUjEnMCUGA1UECxMebkNp
# cGhlciBEU0UgRVNOOjU4NDctRjc2MS00RjcwMSUwIwYDVQQDExxNaWNyb3NvZnQg
# VGltZS1TdGFtcCBTZXJ2aWNloIIUwTCCBnEwggRZoAMCAQICCmEJgSoAAAAAAAIw
# DQYJKoZIhvcNAQELBQAwgYgxCzAJBgNVBAYTAlVTMRMwEQYDVQQIEwpXYXNoaW5n
# dG9uMRAwDgYDVQQHEwdSZWRtb25kMR4wHAYDVQQKExVNaWNyb3NvZnQgQ29ycG9y
# YXRpb24xMjAwBgNVBAMTKU1pY3Jvc29mdCBSb290IENlcnRpZmljYXRlIEF1dGhv
# cml0eSAyMDEwMB4XDTEwMDcwMTIxMzY1NVoXDTI1MDcwMTIxNDY1NVowfDELMAkG
# A1UEBhMCVVMxEzARBgNVBAgTCldhc2hpbmd0b24xEDAOBgNVBAcTB1JlZG1vbmQx
# HjAcBgNVBAoTFU1pY3Jvc29mdCBDb3Jwb3JhdGlvbjEmMCQGA1UEAxMdTWljcm9z
# b2Z0IFRpbWUtU3RhbXAgUENBIDIwMTAwggEiMA0GCSqGSIb3DQEBAQUAA4IBDwAw
# ggEKAoIBAQCpHQ28dxGKOiDs/BOX9fp/aZRrdFQQ1aUKAIKF++18aEssX8XD5WHC
# drc+Zitb8BVTJwQxH0EbGpUdzgkTjnxhMFmxMEQP8WCIhFRDDNdNuDgIs0Ldk6zW
# czBXJoKjRQ3Q6vVHgc2/JGAyWGBG8lhHhjKEHnRhZ5FfgVSxz5NMksHEpl3RYRNu
# KMYa+YaAu99h/EbBJx0kZxJyGiGKr0tkiVBisV39dx898Fd1rL2KQk1AUdEPnAY+
# Z3/1ZsADlkR+79BL/W7lmsqxqPJ6Kgox8NpOBpG2iAg16HgcsOmZzTznL0S6p/Tc
# ZL2kAcEgCZN4zfy8wMlEXV4WnAEFTyJNAgMBAAGjggHmMIIB4jAQBgkrBgEEAYI3
# FQEEAwIBADAdBgNVHQ4EFgQU1WM6XIoxkPNDe3xGG8UzaFqFbVUwGQYJKwYBBAGC
# NxQCBAweCgBTAHUAYgBDAEEwCwYDVR0PBAQDAgGGMA8GA1UdEwEB/wQFMAMBAf8w
# HwYDVR0jBBgwFoAU1fZWy4/oolxiaNE9lJBb186aGMQwVgYDVR0fBE8wTTBLoEmg
# R4ZFaHR0cDovL2NybC5taWNyb3NvZnQuY29tL3BraS9jcmwvcHJvZHVjdHMvTWlj
# Um9vQ2VyQXV0XzIwMTAtMDYtMjMuY3JsMFoGCCsGAQUFBwEBBE4wTDBKBggrBgEF
# BQcwAoY+aHR0cDovL3d3dy5taWNyb3NvZnQuY29tL3BraS9jZXJ0cy9NaWNSb29D
# ZXJBdXRfMjAxMC0wNi0yMy5jcnQwgaAGA1UdIAEB/wSBlTCBkjCBjwYJKwYBBAGC
# Ny4DMIGBMD0GCCsGAQUFBwIBFjFodHRwOi8vd3d3Lm1pY3Jvc29mdC5jb20vUEtJ
# L2RvY3MvQ1BTL2RlZmF1bHQuaHRtMEAGCCsGAQUFBwICMDQeMiAdAEwAZQBnAGEA
# bABfAFAAbwBsAGkAYwB5AF8AUwB0AGEAdABlAG0AZQBuAHQALiAdMA0GCSqGSIb3
# DQEBCwUAA4ICAQAH5ohRDeLG4Jg/gXEDPZ2joSFvs+umzPUxvs8F4qn++ldtGTCz
# wsVmyWrf9efweL3HqJ4l4/m87WtUVwgrUYJEEvu5U4zM9GASinbMQEBBm9xcF/9c
# +V4XNZgkVkt070IQyK+/f8Z/8jd9Wj8c8pl5SpFSAK84Dxf1L3mBZdmptWvkx872
# ynoAb0swRCQiPM/tA6WWj1kpvLb9BOFwnzJKJ/1Vry/+tuWOM7tiX5rbV0Dp8c6Z
# ZpCM/2pif93FSguRJuI57BlKcWOdeyFtw5yjojz6f32WapB4pm3S4Zz5Hfw42JT0
# xqUKloakvZ4argRCg7i1gJsiOCC1JeVk7Pf0v35jWSUPei45V3aicaoGig+JFrph
# pxHLmtgOR5qAxdDNp9DvfYPw4TtxCd9ddJgiCGHasFAeb73x4QDf5zEHpJM692VH
# eOj4qEir995yfmFrb3epgcunCaw5u+zGy9iCtHLNHfS4hQEegPsbiSpUObJb2sgN
# VZl6h3M7COaYLeqN4DMuEin1wC9UJyH3yKxO2ii4sanblrKnQqLJzxlBTeCG+Sqa
# oxFmMNO7dDJL32N79ZmKLxvHIa9Zta7cRDyXUHHXodLFVeNp3lfB0d4wwP3M5k37
# Db9dT+mdHhk4L7zPWAUu7w2gUDXa7wknHNWzfjUeCLraNtvTX4/edIhJEjCCBe0w
# ggPVoAMCAQICECjMOiW/ukSsRJqbWGtDOaowDQYJKoZIhvcNAQELBQAwgYgxCzAJ
# BgNVBAYTAlVTMRMwEQYDVQQIEwpXYXNoaW5ndG9uMRAwDgYDVQQHEwdSZWRtb25k
# MR4wHAYDVQQKExVNaWNyb3NvZnQgQ29ycG9yYXRpb24xMjAwBgNVBAMTKU1pY3Jv
# c29mdCBSb290IENlcnRpZmljYXRlIEF1dGhvcml0eSAyMDEwMB4XDTEwMDYyMzIx
# NTcyNFoXDTM1MDYyMzIyMDQwMVowgYgxCzAJBgNVBAYTAlVTMRMwEQYDVQQIEwpX
# YXNoaW5ndG9uMRAwDgYDVQQHEwdSZWRtb25kMR4wHAYDVQQKExVNaWNyb3NvZnQg
# Q29ycG9yYXRpb24xMjAwBgNVBAMTKU1pY3Jvc29mdCBSb290IENlcnRpZmljYXRl
# IEF1dGhvcml0eSAyMDEwMIICIjANBgkqhkiG9w0BAQEFAAOCAg8AMIICCgKCAgEA
# uQieKOTk7AZOUGizQcV76662jq+BuiJEH2U0aUy+cEAX8hZ74nn9hu0NOfQbqK2S
# kB7LPXaPWtm1kRAuPAWNim0kVOcf7Vatg7RQnBWlF3SIWSD8CMWEdtNo1G8oeM5c
# uPNQkET/42NfvqGaLJYVBNYH/h6EIeBCMRHEKDaUz1CkYp7J1qtxALJbDOaW1Aok
# lvX/xtW3G9fLtyFirxLcoV034xr7GkaYwJvA52MfKgiTAn4eao7ynxiJ5CKForGE
# V0D/9Q7Yb5zt4kUxAc0X6X+wgUXjqiFAJqFyqqdPPAEFfu6DWLFeBmOZYpF4grcN
# kwwkarQb2yfsX5UEP5NKMPWXGLOn+RmnkzMdAcjbIlJc1yXJRvmi+4dZQ76bYrGN
# LYZEGkaseGF+MAn6ronEQSoiZgOROUWcx4sMqMoNL/tS6gz3YzMjnf6wH61n1qdQ
# A8YEcGO1LLGGWkO3+675biluISFBJgaMycPusMKFk6G5hdnmMmxLTD/WXaPltZ13
# w5zAVbd0AOO4OKuDl1DhmkIkHcbAozDRGlrIUjT3c/HHGB8zrXrsy0Fg8yOUIMJI
# RaxcUcYugMLidxW9hYftNp2Wke4AtaNw7J/jjYBog3a6r11wUiIW4mb7urPFwvc+
# L3emyt7BpsZITMM3USPTJ9e4TnCW8KFEdq94z5rhZhMCAwEAAaNRME8wCwYDVR0P
# BAQDAgGGMA8GA1UdEwEB/wQFMAMBAf8wHQYDVR0OBBYEFNX2VsuP6KJcYmjRPZSQ
# W9fOmhjEMBAGCSsGAQQBgjcVAQQDAgEAMA0GCSqGSIb3DQEBCwUAA4ICAQCspZaM
# v7uupvbXcYdDMVaI/RwycVs1t9TwkfKvN+IU8fMCJgU+FhR/FLq4T/uJsrLn1AnM
# bblbO2RlcGa38rFa3xoC8/VRuGdtefO/VnvkhLkrHptAnCY0+UcYmGnYHNe20b+P
# YcJnxLXvYEOOEBs2SeQgyq2nwbEnZQn4zfVbKtCEM/PvH/L1nAtYkzegdaDect5s
# dSpmIvWMBjBWn0C5MKpAdxWC14vswNOyvYPFdwwerq8ZU6BNeXGfD68wzmf51izM
# IkF6B/KXQhjOWXkQVd5vEOS42oNmQBYJaCNbly4mmgK7V4zFuLppYjKAiZ6h/cCS
# fHsrMxmEKmPFAGhi+p9HjZl6RTqn6e3uaUK184GbR1YQe/xwNoQYc+rv+ZdNnjMj
# 3SYLuiq3P0Tcgyf/vWFZKxG3yk/bxYsMHDGuMvj4uUL3f9xhmnaxWgThET1mRbcY
# cb7JJIXW89S6QTRdEi0luY2mE0htS7AHfZmTCWGBdFcmiqtp4+TZx4jMJNjsUiRc
# HryRFOKW3usK2p7dX7Nb29SC7MYgUIclQDr7x+7N/jPlbsOECVUDJTnA6TVdZTGo
# 9r+gCc0px7M2Mi7clfODwVrPi4326rMh+KTtHjEOtkwRq2ALpBIjIhejNmSCkQQS
# 4KtvHstQBWG0QP9ZhnHR1TNpfKlzijjXZAzxaTCCBNowggPCoAMCAQICEzMAAABo
# QjzI8vQZ3IYAAAAAAGgwDQYJKoZIhvcNAQELBQAwfDELMAkGA1UEBhMCVVMxEzAR
# BgNVBAgTCldhc2hpbmd0b24xEDAOBgNVBAcTB1JlZG1vbmQxHjAcBgNVBAoTFU1p
# Y3Jvc29mdCBDb3Jwb3JhdGlvbjEmMCQGA1UEAxMdTWljcm9zb2Z0IFRpbWUtU3Rh
# bXAgUENBIDIwMTAwHhcNMTUwNjA0MTc0NTI1WhcNMTYwOTA0MTc0NTI1WjCBszEL
# MAkGA1UEBhMCVVMxEzARBgNVBAgTCldhc2hpbmd0b24xEDAOBgNVBAcTB1JlZG1v
# bmQxHjAcBgNVBAoTFU1pY3Jvc29mdCBDb3Jwb3JhdGlvbjENMAsGA1UECxMETU9Q
# UjEnMCUGA1UECxMebkNpcGhlciBEU0UgRVNOOjU4NDctRjc2MS00RjcwMSUwIwYD
# VQQDExxNaWNyb3NvZnQgVGltZS1TdGFtcCBTZXJ2aWNlMIIBIjANBgkqhkiG9w0B
# AQEFAAOCAQ8AMIIBCgKCAQEAq0ZXOMFd1N9gGnso8BS4NXkwbvkXM86/6uNCG6ap
# iBF3znB5NJZrGMzEmzYqXsRDlUHfen5NgH/MldHIWexo4LCz+b+jtlm+AgRdl8RC
# /2hj8APt7Dp+YDpa5SPvKktZw1L8IXlzRRd8tE6diNINU+vfXg5tIvtRJqZHWNKO
# Cb4L2G1GNVD41UWa9e/Afqvv0axgn1UfUmmOk1eDETuzu9wMxuicKvRFoNGNuSmI
# 4mSdGExOCvtgRAdIe66R1V2fSrZSgGr1XiryyC4d1UHn8U/V4FtjeXZjDxH00L4u
# bk/53gdoMhm0jTwL6pl4LMh8fjMYmio0NXtoS+JTELg1dQIDAQABo4IBGzCCARcw
# HQYDVR0OBBYEFCuZIStL+uBFGtL/rMencdt4T5K2MB8GA1UdIwQYMBaAFNVjOlyK
# MZDzQ3t8RhvFM2hahW1VMFYGA1UdHwRPME0wS6BJoEeGRWh0dHA6Ly9jcmwubWlj
# cm9zb2Z0LmNvbS9wa2kvY3JsL3Byb2R1Y3RzL01pY1RpbVN0YVBDQV8yMDEwLTA3
# LTAxLmNybDBaBggrBgEFBQcBAQROMEwwSgYIKwYBBQUHMAKGPmh0dHA6Ly93d3cu
# bWljcm9zb2Z0LmNvbS9wa2kvY2VydHMvTWljVGltU3RhUENBXzIwMTAtMDctMDEu
# Y3J0MAwGA1UdEwEB/wQCMAAwEwYDVR0lBAwwCgYIKwYBBQUHAwgwDQYJKoZIhvcN
# AQELBQADggEBAG6TP+70KFyP7kgKcqCbKCvGMauiF9MZ/1VO3HIkVTYB3ZEu90ef
# mULL5L+kZJru5S+PIK8ONjTs1tMFGiPTprRs+ibT+6Qvfovp/o1jyUiSTszAgsxw
# K+5uEi+yJd9W8427p6MrYUXfxndQywmqbqZLHrIfv+d/Ny7ybTSZUV1hQqxKXK+d
# xzxj6A2z4YhwFkEq+cbcOI3xI6VBWM52+MApIlAmoLTw3fsCnKxU2b58xHtWr3yg
# x3QkvHvoP+6rbGyOvcuMHpvcOuqJG+uGYkd+8Lw6/WhTFxy3lJ7388fUCLcTwLHo
# NPc5SprvQNg1S/qLDpthXE0DUIgXPUoeWZuhggN5MIICYQIBATCB46GBuaSBtjCB
# szELMAkGA1UEBhMCVVMxEzARBgNVBAgTCldhc2hpbmd0b24xEDAOBgNVBAcTB1Jl
# ZG1vbmQxHjAcBgNVBAoTFU1pY3Jvc29mdCBDb3Jwb3JhdGlvbjENMAsGA1UECxME
# TU9QUjEnMCUGA1UECxMebkNpcGhlciBEU0UgRVNOOjU4NDctRjc2MS00RjcwMSUw
# IwYDVQQDExxNaWNyb3NvZnQgVGltZS1TdGFtcCBTZXJ2aWNloiUKAQEwCQYFKw4D
# AhoFAAMVAEziTNFDAjKfvMHfruJ4kYKSK6CgoIHCMIG/pIG8MIG5MQswCQYDVQQG
# EwJVUzETMBEGA1UECBMKV2FzaGluZ3RvbjEQMA4GA1UEBxMHUmVkbW9uZDEeMBwG
# A1UEChMVTWljcm9zb2Z0IENvcnBvcmF0aW9uMQ0wCwYDVQQLEwRNT1BSMScwJQYD
# VQQLEx5uQ2lwaGVyIE5UUyBFU046NERFOS0wQzVFLTNFMDkxKzApBgNVBAMTIk1p
# Y3Jvc29mdCBUaW1lIFNvdXJjZSBNYXN0ZXIgQ2xvY2swDQYJKoZIhvcNAQEFBQAC
# BQDZimjYMCIYDzIwMTUwODI4MDQ1ODAwWhgPMjAxNTA4MjkwNDU4MDBaMHcwPQYK
# KwYBBAGEWQoEATEvMC0wCgIFANmKaNgCAQAwCgIBAAICJscCAf8wBwIBAAICGp4w
# CgIFANmLulgCAQAwNgYKKwYBBAGEWQoEAjEoMCYwDAYKKwYBBAGEWQoDAaAKMAgC
# AQACAxbjYKEKMAgCAQACAwehIDANBgkqhkiG9w0BAQUFAAOCAQEACAKzLhGcNfWv
# C/nCwT3GCrnPpW90Zhd2cr83no6wOFFR8rDod3mMDTvUN856iGI/4e6yYEjpxkF5
# BX/kxIgno4icvbs0k2okbo77bPf8vARFQ4aM8oNOcKqvnBz0sMzPIQnjDm2l+MR/
# +PTVLnfc7sbrSfFlH6PA3l2SOz8GMATTTXGqh1ny4JpL5hdPTqRapp9fp0x9gn7S
# 6I7J7griNz+dwhlpuQQKU6ravPzP2CcHiO4Oivv7ziXKbI1QLZ8q2nf8sg8e0tT+
# uO/oj0sUHAnxl8Mk6VQ4gPCWvUH8S+QzMuc2q8tiGYDLO76ZvVCmb6uC3HUbdZjj
# uQPMw5T/CTGCAvUwggLxAgEBMIGTMHwxCzAJBgNVBAYTAlVTMRMwEQYDVQQIEwpX
# YXNoaW5ndG9uMRAwDgYDVQQHEwdSZWRtb25kMR4wHAYDVQQKExVNaWNyb3NvZnQg
# Q29ycG9yYXRpb24xJjAkBgNVBAMTHU1pY3Jvc29mdCBUaW1lLVN0YW1wIFBDQSAy
# MDEwAhMzAAAAaEI8yPL0GdyGAAAAAABoMA0GCWCGSAFlAwQCAQUAoIIBMjAaBgkq
# hkiG9w0BCQMxDQYLKoZIhvcNAQkQAQQwLwYJKoZIhvcNAQkEMSIEICl6v1taWa5J
# QJcRiU3SW9LQf3BYgF4DQBGnTMftZGRqMIHiBgsqhkiG9w0BCRACDDGB0jCBzzCB
# zDCBsQQUTOJM0UMCMp+8wd+u4niRgpIroKAwgZgwgYCkfjB8MQswCQYDVQQGEwJV
# UzETMBEGA1UECBMKV2FzaGluZ3RvbjEQMA4GA1UEBxMHUmVkbW9uZDEeMBwGA1UE
# ChMVTWljcm9zb2Z0IENvcnBvcmF0aW9uMSYwJAYDVQQDEx1NaWNyb3NvZnQgVGlt
# ZS1TdGFtcCBQQ0EgMjAxMAITMwAAAGhCPMjy9BnchgAAAAAAaDAWBBTAtKtAvBlo
# dL0qsdlp194t+kPlhzANBgkqhkiG9w0BAQsFAASCAQBE291ykL19Fj3egVEIdZ9B
# zKTke9pYyzU05VflyGWieOMhr2YKPTSY880RiPyrhWunawE5Me7daQ4jD04w1IBU
# pKvOQ+Anf+bOHMjESIXy64sbJ3NYLhOdXtF1BZqehKb7GZ9b7TjYZwg0B0ou+9Aj
# XA79Mz1hh1aUznwp7tlPACF2I9CTpU/Jq5m+kUbL/mll7XDMhqVmfNhizhXFMOAR
# s9YH4FIoVRxlevuUfPSLFGM2ZcmKXG+v32LZRBybRhKyHVdVCLkogD8oWiiCSNCN
# Q/+2FN5hyp7fyPZKOS09iXTgzQzj/wo8oSozyHSMf9DHvTwVhzE4/+WoaTijtKOH
# SIG # End signature block