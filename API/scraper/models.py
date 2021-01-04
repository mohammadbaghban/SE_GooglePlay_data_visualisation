from django.db import models


class Data(models.Model):
    ApplicationName = models.CharField(default='', blank=False, null=True, max_length=4200)
    Category = models.CharField(default='', blank=False, null=True, max_length=4200)
    OverallUserRating = models.CharField(default='', blank=False, null=True, max_length=4200)
    NumberOfUsersReviews = models.CharField(default='', blank=False, null=True, max_length=4200)
    Size = models.CharField(default='', blank=False, null=True, max_length=4200)
    NumberOfUserDownloads = models.PositiveIntegerField(default=0, blank=True, null=True)
    PaidOrFree = models.CharField(default='', blank=False, null=True, max_length=4200)
    Price = models.CharField(default='', blank=False, null=True, max_length=4200)
    AgeGroup = models.CharField(default='', blank=False, null=True,
                                max_length=4200)
    Genres = models.CharField(default='', blank=False, null=True, max_length=4200)

    def __unicode__(self):
        if self.ApplicationName is not None:
            return self.ApplicationName
        else:
            return ''

    def __str__(self):
        if self.ApplicationName is not None:
            return self.ApplicationName
        else:
            return ''
