import os
import django

os.environ.setdefault("DJANGO_SETTINGS_MODULE", "API.settings")
django.setup()

from rest_framework.test import APIClient


def get_by_number(number):
    client = APIClient()
    data = {
        'number': number}
    respond = client.get('/api/get_by_download', data)
    return respond


def get_all():
    client = APIClient()
    respond = client.get('/api/get')
    return respond


print(get_by_number(number=10).json())
print(get_all().json())
