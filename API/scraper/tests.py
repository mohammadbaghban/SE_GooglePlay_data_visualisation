from django.test import TestCase
import requests

# Create your tests here.
data = {'number':10}
r = requests.post('http://127.0.0.1:8000/api/get_by_download', data=data)
print(r.text)