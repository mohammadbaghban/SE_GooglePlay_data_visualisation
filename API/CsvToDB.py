import csv
from django.conf import settings
import API.settings as app_settings

settings.configure(INSTALLED_APPS=app_settings.INSTALLED_APPS, DATABASES=app_settings.DATABASES)
import django

django.setup()
from scraper.models import Data


def data_extractor():
    csv_reader = csv.reader(open('googleplaystore.csv', encoding="utf8"))
    data = {}
    for line in csv_reader:
        data[str(line[0])] = [
            str(line[1]),
            str(line[2]),
            str(line[3]),
            str(line[4]),
            str(line[5]),
            str(line[6]),
            str(line[7]),
            str(line[8]),
            str(line[9]),
        ]
    return data


for key, value in data_extractor().items():
    print(key, value)
    add_to_db, created = Data.objects.get_or_create(ApplicationName=key)
    add_to_db.Category = value[0]
    add_to_db.OverallUserRating = value[1]
    add_to_db.NumberOfUsersReviews = value[2]
    add_to_db.Size = value[3]
    add_to_db.NumberOfUserDownloads = value[4]
    add_to_db.PaidOrFree = value[5]
    add_to_db.Price = value[6]
    add_to_db.AgeGroup = value[7]
    add_to_db.Genres = value[8]
    add_to_db.save()
