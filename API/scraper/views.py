from django.shortcuts import render

# Create your views here.
from rest_framework import status
from rest_framework.response import Response
from rest_framework.views import APIView
from .models import Data


class Post(APIView):
    def post(self, request, format=None):
        app_name = request.Post.get('app_name', None)
        category = request.Post.get('category', None)
        rating = request.Post.get('rating', None)
        reviews = request.Post.get('reviews', None)
        size = request.Post.get('size', None)
        downloads = request.Post.get('downloads', None)
        paid_or_free = request.Post.get('paid_or_free', None)
        price = request.Post.get('price', None)
        age_group = request.Post.get('age_group', None)
        genres = request.Post.get('genres', None)

        model, d = Data.objects.get_or_create()
        model.ApplicationName = app_name
        model.Category = category
        model.OverallUserRating = rating
        model.NumberOfUsersReviews = reviews
        model.Size = size
        model.NumberOfUserDownloads = downloads
        model.PaidOrFree = paid_or_free
        model.Price = price
        model.AgeGroup = age_group
        model.Genres = genres
        model.save()

        result = {'data': str(app_name)}

        return Response(data=result, status=status.HTTP_200_OK)


class Get(APIView):
    def get(self, request, format=None):
        model = Data.objects.all()
        data = {}
        for item in model:
            data[item.ApplicationName] = [item.Category, item.OverallUserRating, item.NumberOfUsersReviews,
                                          item.NumberOfUsersReviews,
                                          item.Size, item.NumberOfUserDownloads, item.PaidOrFree, item.Price,
                                          item.AgeGroup, item.Genres]

        return Response(data=data, status=status.HTTP_200_OK)


class GetByFilterDownloadNumberAscending(APIView):
    def get(self, request):
        try:
            number = request.GET.get('number', None)
            model = Data.objects.order_by('-NumberOfUserDownloads')[:int(number)]
            data = {}
            temp = []
            for item in model:
                temp.append({"ApplicationName": item.ApplicationName, "Category": item.Category,
                             "OverallUserRating": item.OverallUserRating,
                             "NumberOfUsersReviews": item.NumberOfUsersReviews,
                             "Size": item.Size, "NumberOfUserDownloads": item.NumberOfUserDownloads,
                             "PaidOrFree": item.PaidOrFree, "Price": item.Price,
                             "AgeGroup": item.AgeGroup, "Genres": item.Genres})
            data['apps'] = temp
            return Response(data=data, status=status.HTTP_200_OK)
        except Exception as e:
            data = {'ERROR': str(e)}
            return Response(data=data, status=status.HTTP_200_OK)
