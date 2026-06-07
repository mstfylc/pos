//
// AUTO-GENERATED FILE, DO NOT MODIFY!
//
// @dart=2.7

// ignore_for_file: unused_import

import 'package:built_value/built_value.dart';
import 'package:built_value/serializer.dart';

part 'category_write_dto.g.dart';

abstract class CategoryWriteDto implements Built<CategoryWriteDto, CategoryWriteDtoBuilder> {

    @BuiltValueField(wireName: r'companyId')
    String get companyId;

    @BuiltValueField(wireName: r'userId')
    String get userId;

    @BuiltValueField(wireName: r'name')
    String get name;

    @BuiltValueField(wireName: r'sortOrder')
    int get sortOrder;

    @BuiltValueField(wireName: r'categoryColorId')
    String get categoryColorId;

    @BuiltValueField(wireName: r'categoryShapeId')
    String get categoryShapeId;

    CategoryWriteDto._();

    static void _initializeBuilder(CategoryWriteDtoBuilder b) => b;

    factory CategoryWriteDto([void updates(CategoryWriteDtoBuilder b)]) = _$CategoryWriteDto;

    @BuiltValueSerializer(custom: true)
    static Serializer<CategoryWriteDto> get serializer => _$CategoryWriteDtoSerializer();
}

class _$CategoryWriteDtoSerializer implements StructuredSerializer<CategoryWriteDto> {

    @override
    final Iterable<Type> types = const [CategoryWriteDto, _$CategoryWriteDto];
    @override
    final String wireName = r'CategoryWriteDto';

    @override
    Iterable<Object> serialize(Serializers serializers, CategoryWriteDto object,
        {FullType specifiedType = FullType.unspecified}) {
        final result = <Object>[];
        result
            ..add(r'companyId')
            ..add(serializers.serialize(object.companyId,
                specifiedType: const FullType(String)));
        result
            ..add(r'userId')
            ..add(serializers.serialize(object.userId,
                specifiedType: const FullType(String)));
        result
            ..add(r'name')
            ..add(serializers.serialize(object.name,
                specifiedType: const FullType(String)));
        result
            ..add(r'sortOrder')
            ..add(serializers.serialize(object.sortOrder,
                specifiedType: const FullType(int)));
        result
            ..add(r'categoryColorId')
            ..add(serializers.serialize(object.categoryColorId,
                specifiedType: const FullType(String)));
        result
            ..add(r'categoryShapeId')
            ..add(serializers.serialize(object.categoryShapeId,
                specifiedType: const FullType(String)));
        return result;
    }

    @override
    CategoryWriteDto deserialize(Serializers serializers, Iterable<Object> serialized,
        {FullType specifiedType = FullType.unspecified}) {
        final result = CategoryWriteDtoBuilder();

        final iterator = serialized.iterator;
        while (iterator.moveNext()) {
            final key = iterator.current as String;
            iterator.moveNext();
            final dynamic value = iterator.current;
            switch (key) {
                case r'companyId':
                    result.companyId = serializers.deserialize(value,
                        specifiedType: const FullType(String)) as String;
                    break;
                case r'userId':
                    result.userId = serializers.deserialize(value,
                        specifiedType: const FullType(String)) as String;
                    break;
                case r'name':
                    result.name = serializers.deserialize(value,
                        specifiedType: const FullType(String)) as String;
                    break;
                case r'sortOrder':
                    result.sortOrder = serializers.deserialize(value,
                        specifiedType: const FullType(int)) as int;
                    break;
                case r'categoryColorId':
                    result.categoryColorId = serializers.deserialize(value,
                        specifiedType: const FullType(String)) as String;
                    break;
                case r'categoryShapeId':
                    result.categoryShapeId = serializers.deserialize(value,
                        specifiedType: const FullType(String)) as String;
                    break;
            }
        }
        return result.build();
    }
}

